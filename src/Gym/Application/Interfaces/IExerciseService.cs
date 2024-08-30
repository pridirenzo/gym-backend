﻿using Application.Models;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IExerciseService
    {
        ICollection<ExerciseDto> GetAllExercise();
        ICollection<ExerciseDto> GetExerciseByCategory(Category category);
        ExerciseDto GetExerciseById(int id);
    }
}
