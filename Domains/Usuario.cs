using System;
using System.Collections.Generic;

namespace RedeAurora.Domains;

public partial class Usuario
{
    public Guid id_usuario { get; set; }

    public string nome { get; set; } = null!;

    public byte[] senha { get; set; } = null!;

    public string? email { get; set; }

    public virtual ICollection<ItemInventario> ItemInventario { get; set; } = new List<ItemInventario>();
}
