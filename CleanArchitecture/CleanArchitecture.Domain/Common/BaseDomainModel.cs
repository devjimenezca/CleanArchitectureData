﻿namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Estado { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
