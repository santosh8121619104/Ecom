﻿using System;
using System.Collections.Generic;

namespace Lms.Api.Models;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int? ModuleId { get; set; }

    public string? LessonName { get; set; }

    public string? Content { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Module? Module { get; set; }

    public virtual ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
}
