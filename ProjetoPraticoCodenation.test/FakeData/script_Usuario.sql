Use ProjetoPratico


insert into dbo.Usuario (
nm_usuario
,nm_login
,ds_senha
,cd_token
,email
)

select
nm_usuario = 'Elis Souza'
,nm_login = 'ls.sz'
,ds_senha = '456'
,cd_token = 'JAHEU573IJE09'
,email = 'elis@email.com'

union all

select
nm_usuario = 'Raquel Prates'
,nm_login = 'rql.prts'
,ds_senha = '789'
,cd_token = '0OUIJSSAHEU07'
,email = 'raquel@email.com'

union all

select
nm_usuario = 'Sheyla Araujo'
,nm_login = 'shyl.rj'
,ds_senha = '147'
,cd_token = 'AAA57KIAKLLAA'
,email = 'sheyka@email.com'

union all

select
nm_usuario = 'Agatha Nigro'
,nm_login = 'gth.ngr'
,ds_senha = '123'
,cd_token = 'KKKKKKKKSASA'
,email = 'agatha@email.com'



