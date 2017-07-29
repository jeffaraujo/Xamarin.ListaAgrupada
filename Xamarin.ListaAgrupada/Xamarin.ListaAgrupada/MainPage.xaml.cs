using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.ListaAgrupada
{
    public partial class MainPage : ContentPage
    {

        private List<Livro> _livros;

        public MainPage()
        {
            InitializeComponent();

            this._livros = new List<Livro>();
            this._livros.Add( new Livro() {Nome = "Iracema", Autor = "José de Alencar"});
            this._livros.Add(new Livro() { Nome = "O Guarani", Autor = "José de Alencar" });
            this._livros.Add(new Livro() { Nome = "Animais em Extinção", Autor = "Marcelo Mirisola" });
            this._livros.Add(new Livro() { Nome = "Como Desaparecer Completamente", Autor = "André Leones" });
            this._livros.Add(new Livro() { Nome = "O Diário de um Mago", Autor = "Paulo Coelho" });
            this._livros.Add(new Livro() { Nome = "Brida", Autor = "Paulo Coelho" });
            this._livros.Add(new Livro() { Nome = "O Alquimista", Autor = "Paulo Coelho" });
            this._livros.Add(new Livro() { Nome = "No Buraco", Autor = "Tony Belloto" });
            this._livros.Add(new Livro() { Nome = "Mentes Perigosas", Autor = "Ana Beatriz Barbosa Silva" });
            this._livros.Add(new Livro() { Nome = "O Tigre Na Sombra", Autor = "Lya Luft" });
            this._livros.Add(new Livro() { Nome = "O Lado Fatal", Autor = "Lya Luft" });
            this._livros.Add(new Livro() { Nome = "O Crepúculo do Macho", Autor = "Fernando Gabeira" });
            this._livros.Add(new Livro() { Nome = "O Xangôe Baker Street", Autor = "Jô Soares" });
            this._livros.Add(new Livro() { Nome = "As Esganadas", Autor = "Jô Soares" });
            this._livros.Add(new Livro() { Nome = "Mar Morto", Autor = "Jorge Amado" });
            this._livros.Add(new Livro() { Nome = "Memórias de um Sargento de Milícias", Autor = "Manuel Antônio de Almeida" });
            this._livros.Add(new Livro() { Nome = "Estorvo", Autor = "Chico Buarque" });
            this._livros.Add(new Livro() { Nome = "O Mundo não é chato", Autor = "Caetano Veloso" });
            this._livros.Add(new Livro() { Nome = "Triângulo no Ponto", Autor = "Eros Grau" });
            this._livros.Add(new Livro() { Nome = "A Paixão Segundo G.H.", Autor = "Clarice Lispector" });
            this._livros.Add(new Livro() { Nome = "O Inverno das Fadas", Autor = "Carolina Munhóz" });
            this._livros.Add(new Livro() { Nome = "O Dia Mastroianni", Autor = "João Paulo Cuenca" });
            this._livros.Add(new Livro() { Nome = "A Vida Sabe o Que Faz", Autor = "Zibia Gasparetto" });
            this._livros.Add(new Livro() { Nome = "A Escrava Isaura", Autor = "Bernardo Guimarães" });
            this._livros.Add(new Livro() { Nome = "Farewell", Autor = "Carlos Drummond de Andrade" });
            this._livros.Add(new Livro() { Nome = "Rosinha, Minha Canoa", Autor = "Joséauro de Vasconcelos" });
            this._livros.Add(new Livro() { Nome = "Obra Completa", Autor = "J. G. de Araujo Jorge" });
            this._livros.Add(new Livro() { Nome = "Guia-Mapa de Gabriel Arcanjo", Autor = "Néia Piñn" });

            this.lista.ItemsSource = this.Listar();


            this.busca.TextChanged += Busca_TextChanged;

        }

        private void Busca_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.lista.ItemsSource = this.Listar(busca.Text);
        }

        public IEnumerable<Group<char, Livro>> Listar(string filtro = "")
        {
            IEnumerable<Livro> livrosFiltrados = this._livros;


            if (!string.IsNullOrEmpty(filtro))
               livrosFiltrados =_livros.Where(l => l.Nome.ToLower().Contains(filtro.ToLower()) || l.Autor.ToLower().Contains(filtro.ToLower()));


            return from livro in livrosFiltrados
                orderby livro.Nome
                group livro by livro.Nome[0] into grupos
                select new Group<char, Livro>(grupos.Key, grupos);
        }
    }
}
