using MauiAppMinhasCompras.Models; // permite usar a classe Produto
using SQLite; // dá acesso às funcionalidades do SQLite, como SQLiteAsyncConnection


namespace MauiAppMinhasCompras.Helpers // Define que essa classe está dentro do namespace Helpers,
                                       // separando a lógica de banco de dados do restante do projeto.

{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        // Declara uma conexão assíncrona com o banco de dados que não pode ser alterada depois de criada.


        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }
        // Este Construtor de Classe cria a conexão com o banco de dados usando o caminho do arquivo .db3
        // e garante que a tabela Produto exista ao iniciar o aplicativo.



        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }
        // O método Insert insere um novo produto no banco e retorna um int com o número de registros inseridos na operação.


        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE ID=?";

            return _conn.QueryAsync<Produto>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
                );
        }
        // O método Update atualiza os dados de um produto com base no Id e retorna uma lista de produtos.


        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.Id == id);
        }
        // O método Delete exclui um produto pelo Id e retorna um int com o número de registros excluídos. 


        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }
        // O método GetAll retorna uma lista com todos os produtos cadastrados no banco de dados.


        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE descricao LIKE '%" + q + "%'";

            return _conn.QueryAsync<Produto>(sql);
        }
        // O método Search busca produtos pela descrição e retorna uma lista com os resultados encontrados.


    }
}
