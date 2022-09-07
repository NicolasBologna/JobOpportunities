Select * from dbo.AspNetUsers
Select * from [dbo].[JobOffers]
Select * from [dbo].[CandidateJobOffer]

delete from [dbo].[JobOffers] where Id = '5CFE1935-3A8E-418A-A260-38D0551D5027' -- Borra el job offer y su relación con los candidatos

delete from [dbo].[AspNetUsers] where Id = 'F47890B6-A3CE-4057-94A9-AF862D2C01DE' -- Borra el candidato y su relación con las job offers

delete from [dbo].[AspNetUsers] where Id = '1B1D13DD-AFB4-474F-A60A-BF6AB3474898'