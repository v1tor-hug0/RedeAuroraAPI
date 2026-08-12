using System;
using System.Collections.Generic;

namespace RedeAurora.Domains;

public partial class ItemInventario
{
    public int id_item { get; set; }

    public string codigo_patrimonio { get; set; } = null!;

    public string descricao { get; set; } = null!;

    public int id_setor { get; set; }

    public string condicao { get; set; } = null!;

    public DateTime data_hora { get; set; }

    public Guid? id_usuario { get; set; }

    public string? nome { get; set; }

    public virtual Setor id_setorNavigation { get; set; } = null!;

    public virtual Usuario? id_usuarioNavigation { get; set; }
}
