namespace DIO.Series
{
	public class Serie : EntidadeBase
	{
		private Genero genero { get; set; }
		private string titulo { get; set; }
		private string descricao { get; set; }
		private int ano { get; set;}
		private bool excluido { get; set; }
		
		public Serie(int Id, Genero genero, string Titulo, string Descricao, int Ano)
		{
			this.ID = Id;
			this.genero = genero;
			this.titulo = Titulo;
			this.descricao = Descricao;
			this.ano = Ano;
			this.excluido = false;
		}
		
		public override string ToString()
		{
			string retorno = "";
			retorno += "Gênero" + this.genero + Environment.NewLine;
			retorno += "Título" + this.titulo + Environment.NewLine;
			retorno += "Descrição" + this.descricao + Environment.NewLine;
			retorno += "Ano" + this.ano + Environment.NewLine;
			retorno += "Excluído" + this.excluido;
			return retorno;
		}
		
		public string RetornaTitulo()
		{
			return this.titulo;
		}
		
		public int RetornaId()
		{
			return this.ID;
		}
		
		public bool RetornaExcluido()
		{
			return this.excluido;
		}
		
		public void Excluir()
		{
			this.excluido = true;
		}
	}
}