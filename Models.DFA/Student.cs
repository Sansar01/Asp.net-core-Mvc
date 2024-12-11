using System;
using System.Collections.Generic;

namespace Asp.net_core_Mvc.Models.DFA;

public partial class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; } = null!;

    public string StudentGender { get; set; } = null!;

    public int Age { get; set; }

    public string Branch { get; set; } = null!;
}
