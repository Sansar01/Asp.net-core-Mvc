using System;
using System.Collections.Generic;

namespace Asp.net_core_Mvc.Models.DFA;

public partial class Teacher
{
    public decimal Id { get; set; }

    public string TeacherName { get; set; } = null!;

    public string TeacherAddress { get; set; } = null!;

    public decimal Salary { get; set; }
}
