using System;
namespace Event.Uau.Comum.ViewModel
{
    public abstract class DecricaoIdViewModel<T>
    {
        public T Id { get; set; }

        public string Descricao { get; set; }
    }
}
