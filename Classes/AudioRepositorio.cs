using System;
using System.Collections.Generic;
using livros.Interfaces;

namespace livros
{
    public class AudioRepositorio : IRepositorio<Audio>
    {
        private List<Audio> ListaLivros = new List<Audio>();
        public void Atualiza(int Id, Audio objeto)
        {
            ListaLivros[Id] = objeto;
        }
        public void Exclui(int Id)
        {
            ListaLivros[Id].Excluir();
        }
        public void Insere(Audio objeto)
        {
            ListaLivros.Add(objeto);
        }
        public List<Audio> Lista()
        {
            return ListaLivros;
        }
        public int ProximoId()
        {
            return  ListaLivros.Count;
        }
        public Audio RetornaPorId(int Id)
        {
            return  ListaLivros[Id];
        }
    }
}