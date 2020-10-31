﻿namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class ContainedWeightPrereq
    {
        public int Id { get; set; }
        public string Has { get; set; }
        public string Compare { get; set; }
        public string Value { get; set; }
        public int? IdPrqList { get; set; }

        public virtual PrereqListDb IdPrqListNavigation { get; set; }
    }
}