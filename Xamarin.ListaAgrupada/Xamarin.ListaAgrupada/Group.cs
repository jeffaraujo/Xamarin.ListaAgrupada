using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Xamarin.ListaAgrupada
{
    public class Group<TKey, TItem> :ObservableCollection<TItem>
    {
        public TKey Key { get; private set; }


        public Group(TKey key, IEnumerable<TItem> items )
        {
            this.Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }

    }
}
