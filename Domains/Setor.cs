using System;
using System.Collections.Generic;

namespace RedeAurora.Domains;

public partial class Setor
{
    public int id_setor { get; set; }

    public string nome { get; set; } = null!;

    public int id_unidade { get; set; }

    public virtual ICollection<ItemInventario> ItemInventario { get; set; } = new List<ItemInventario>();

    public virtual Unidade id_unidadeNavigation { get; set; } = null!;
}
