using System;
using System.Collections.Generic;

namespace FireFly_Dotnet.Entities;

public partial class StoryLine
{
    public int Id { get; set; }

    public int? StepNum { get; set; }

    public string? NarrativeStep { get; set; }

    public string? Media { get; set; }

    public string? Question { get; set; }

    public int? QuestionTypeId { get; set; }

    public int GradeLevel { get; set; }

    public string Qoption1 { get; set; } = null!;

    public string Qoption2 { get; set; } = null!;

    public string? Qoption3 { get; set; }

    public string? Qoption4 { get; set; }

    public string? Qoption5 { get; set; }

    public string? Qoption6 { get; set; }

    public string? Qoption7 { get; set; }

    public string? Qoption8 { get; set; }

    public string? Qoption9 { get; set; }

    public string? Qoption10 { get; set; }

    public int CorrectAnswerOption { get; set; }

    public bool? IsStudentCorrect { get; set; }

    public int? NextStepIfCorrect { get; set; }

    public int? NextStepIfWrong { get; set; }

    public int StoryId { get; set; }

    public string? StepCcssreference { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? CreatedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public int? ModifiedById { get; set; }
}
