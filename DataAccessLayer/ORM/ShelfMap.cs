namespace DataAccessLayer.ORM
{
    using Domain;
    using FluentNHibernate.Mapping;

    internal class ShelfMap : ClassMap<Shelf>
    {
        public ShelfMap()
        {
            this.Table("Shelves");

            this.Id(x => x.Id);

            this.Map(x => x.Number)
                .Not.Nullable()
                .Unique();
        }
    }
}
