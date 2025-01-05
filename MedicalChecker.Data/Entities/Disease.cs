﻿namespace MedicalChecker.Data.Entities
{
    public class Disease
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DiseasePrecaution> DiseasePrecautions { get; set; }
    }
}
