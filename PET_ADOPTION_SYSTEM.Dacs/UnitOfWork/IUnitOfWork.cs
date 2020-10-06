namespace PET_ADOPTION_SYSTEM.Dacs
{
    public interface IUnitOfWork
    {
        IAnimalImageDac animalImageDac { get; set; }
        IAnimalPostDac animalPostDac { get; set; }
        IMemberDac memberDac { get; set; }
        void Begin();
        void Commit();
        void Open();
    }
}