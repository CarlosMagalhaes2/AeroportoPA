# Projeto Final Programação Avançada
Projeto Realizado por Carlos Magalhães, Bruno Costa e Rodrigo Silva

### Estrutura da Base de Dados
#### Tabela Voo

|Campo|Tipo de Dados|Descrição|
|---|---|---|
|VooId|int|Id do Voo|
|LocalPartida|nvarchar(30)|Local de onde o voo parte|
|LocalChegada|nvarchar(30)|Local onde o voo chega|
|DataPartida|dateTime|Data de partida|
|DataChegada|dateTime|Data de chegada|
|Lotacao|int|Numero de passageiros que vai no voo|
|Capacidade|int|Capacidade máxima para o voo|
|Estado|ENUM|Se o voo foi cancelado, atrasado ou normal|
|CompanhiaId|int|id da companhia aérea|

#### Tabela Companhia

|Campo|Tipo de Dados|Descrição|
|---|---|---|
|CompanhiaId|int|id da companhia aérea|
|Descricao|nvarchar(30)|Nome da companhia|

### ENUM Estado

|Numero|Valor|Descrição|
|---|---|---|
|0|Normal|O voo correu normalmente|
|1|Atrasado|O voo está atrasado|
|2|Cancelado|O voo foi cancelado|
