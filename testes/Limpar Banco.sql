DELETE FROM dbo.log_erros

DBCC CHECKIDENT ('dbo.log_erros', RESEED, 0)

--DELETE FROM AspNetUsers