using System;
using System.Collections.Generic;

namespace RedeAurora.Domains;

public partial class Unidade
{
    public int id_unidade { get; set; }

    public string nome { get; set; } = null!;

    public virtual ICollection<Setor> Setor { get; set; } = new List<Setor>();
}
