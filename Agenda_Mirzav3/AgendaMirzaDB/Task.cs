using System;
using System.Collections.Generic;

namespace Agenda_Mirzav3.AgendaMirzaDB;

public partial class Task
{
    public int IdTask { get; set; }

    public string Name { get; set; } = null!;

    public sbyte Check { get; set; }

    public int ToDoListIdToDoList { get; set; }
}
