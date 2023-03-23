using System;
using System.Collections.Generic;

namespace ClassLibrary.Entities;

public partial class MoneyDetail
{
    public int? Id { get; set; }

    public int AmtSend { get; set; }

    public decimal AmtRecieve { get; set; }

    public string SenderName { get; set; } = null!;

    public string RecieverName { get; set; } = null!;

    public String? Purpose { get; set; }
}
