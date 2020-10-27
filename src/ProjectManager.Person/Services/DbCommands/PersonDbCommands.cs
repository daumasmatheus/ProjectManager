namespace ProjectManager.Person.Services.DbCommands
{
    public static class PersonDbCommands
    {
        //GET
        public static string SELECT_ALL_PERSON = "SELECT * FROM Person";
        public static string SELECT_PERSON_BY_ID = "SELECT * FROM Person WHERE PersonId = @PersonId";

        //POST
        public static string INSERT_NEW_PERSON_DATA = @"INSERT INTO Person (UserId, FirstName, LastName, [Address], ZipCode, City, Telephone, Country, CompanyName, Email, CreatedDate, IsActive)
                                                        VALUES (@UserId, @FirstName, @LastName, @Address, @ZipCode, @City, @Telephone, @Country, @CompanyName, @Email, @CreatedDate, @IsActive)";
    }
}
