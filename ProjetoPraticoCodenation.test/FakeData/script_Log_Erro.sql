Use ProjetoPratico

insert into dbo.log_erros(
ds_titulo_log
,ds_log
,dt_criacao
,cd_evento
,cd_nivel
,ds_ambiente
,ds_origem
,fl_arquivado
,nm_usuario_origem
)

select
ds_titulo_log = 'Erro ao logar no sistema'
,ds_log = 'erro 504 Gateway Timeout'
,dt_criacao = '2020-04-07 19:17:08'
,cd_evento = '1000'
,cd_nivel = 'error'
,ds_ambiente = 'Produção'
,ds_origem = '127.0.0.1'
,fl_arquivado = 0
,nm_usuario_origem = 'admin'

union all

select
ds_titulo_log = 'Erro carregar pagina'
,ds_log =  '404 não encontrado.'
,dt_criacao = '2019-05-24 9:53:10'
,cd_evento = '1000'
,cd_nivel =  'error'
,ds_ambiente = 'Produção'
,ds_origem =  '127.0.0.10'
,fl_arquivado = 1
,nm_usuario_origem = 'anigro'

union all

select
ds_titulo_log = 'Erro acessar site'
,ds_log =  '500 – erro interno do servidor'
,dt_criacao = '2020-04-01 10:20:30'
,cd_evento =  '300'
,cd_nivel =  'warning'
,ds_ambiente ='Desenvolvimento'
,ds_origem =  '10.0.0.1'
,fl_arquivado = 0
,nm_usuario_origem = 'elis'

union all

select
ds_titulo_log = 'Erro mudar senha do usuario'
,ds_log = '403 Proibido'
,dt_criacao = '2020-04-03 00:00:00'
,cd_evento = '100'
,cd_nivel =  'debug'
,ds_ambiente = 'Homologação'
,ds_origem =  'app.server.com.br'
,fl_arquivado = 0
,nm_usuario_origem = 'raquel'

union all

select
ds_titulo_log =  'Erro ao acessar relatorio 1000'
,ds_log =  'Erro 503 Serviço Indisponível'
,dt_criacao = '2020-03-07 13:00:18'
,cd_evento =  '11'
,cd_nivel =  'error'
,ds_ambiente = 'Desenvolvimento'
,ds_origem = 'app.server.com.br'
,fl_arquivado = 1
,nm_usuario_origem = 'sheyla'