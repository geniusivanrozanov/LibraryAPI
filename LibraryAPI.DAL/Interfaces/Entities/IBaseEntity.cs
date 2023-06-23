namespace LibraryAPI.DAL.Interfaces.Entities;

public interface IBaseEntity<TKey>
{
    TKey Id { get; set; }
}