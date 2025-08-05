﻿using EventModular.Shared.Constants;

namespace EventModular.Shared.Base.Entities;

[Table(nameof(Provience), Schema = nameof(SchemaConsts.@base))]

public class Provience : BaseEntity
{
    public Guid CountryId { get; set; }
    public Country Country { get; set; }
    public string Name { get; set; }

    #region Navigation properties
    public ICollection<City> CountryStates { get; set; }
    #endregion
}
