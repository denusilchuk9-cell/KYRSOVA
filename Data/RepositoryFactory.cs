namespace ElectronicJournal.Data
{
    public static class RepositoryFactory
    {
        public static DataAccess CreateDataAccess()
        {
            return new DataAccess();
        }
    }
}