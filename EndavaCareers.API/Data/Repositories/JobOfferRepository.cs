using Dapper;
using EndavaCareers.API.Contracts;
using EndavaCareers.API.Dto;
using EndavaCareers.API.Entities;
using System.Data;

namespace EndavaCareers.API.Data.Repositories;

public class JobOfferRepository : IJobOfferRepository
{
    private readonly DapperContext _context;
    public JobOfferRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<JobOffer>> GetJobOffers()
    {
        var query = "SELECT * FROM JobOffers";
        using (var connection = _context.CreateConnection())
        {
            var jobOffers = await connection.QueryAsync<JobOffer>(query);
            return jobOffers.ToList();
        }
    }

    public async Task<JobOffer> GetJobOffer(int id)
    {
        var query = "SELECT * FROM JobOffers WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            var company = await connection.QuerySingleOrDefaultAsync<JobOffer>(query, new { id });
            return company;
        }
    }

    public async Task<JobOffer> CreateJobOffer(JobOfferForCreationDto jobOffer)
    {
        var query = "INSERT INTO JobOffers (Title, Description, ValidUntil) VALUES (@Title, @Description, @ValidUntil) " +
            "SELECT CAST(SCOPE_IDENTITY() as int)";

        var parameters = new DynamicParameters();
        parameters.Add("Title", jobOffer.Title, DbType.String);
        parameters.Add("Description", jobOffer.Description, DbType.String);
        parameters.Add("ValidUntil", jobOffer.ValidUntil, DbType.Date);
        using (var connection = _context.CreateConnection())
        {
            var id = await connection.QuerySingleAsync<int>(query, parameters);
            var createdJobOffer = new JobOffer
            {
                Id = id,
                Title = jobOffer.Title,
                Description = jobOffer.Description,
                ValidUntil = jobOffer.ValidUntil
            };
            return createdJobOffer;
        }
    }

    public async Task UpdateJobOffer(int id, JobOfferForUpdateDto jobOffer)
    {
        var query = "UPDATE JobOffers SET Title = @Title, Description = @Description, ValidUntil = @ValidUntil WHERE Id = @Id";
        var parameters = new DynamicParameters();
        parameters.Add("Id", id, DbType.Int32);
        parameters.Add("Title", jobOffer.Title, DbType.String);
        parameters.Add("Description", jobOffer.Description, DbType.String);
        parameters.Add("ValidUntil", jobOffer.ValidUntil, DbType.Date);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
    public async Task DeleteJobOffer(int id)
    {
        var query = "DELETE FROM JobOffers WHERE Id = @Id";
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, new { id });
        }
    }
}
