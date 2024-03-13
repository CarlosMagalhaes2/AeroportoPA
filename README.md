# Projeto Final Programação Avançada
Projeto Realizado por Carlos Magalhães, Bruno Costa e Rodrigo Silva

### Estrutura da Base de Dados
#### Tabela Voo

|Campo|Tipo de Dados|Descrição|
|---|---|---|
|voo_id|int|Id do Voo|
|local_partida|nvarchar(30)|Local de onde o voo parte|
|local_chegada|nvarchar(30)|Local onde o voo chega|
|data_partida|dateTime|Data de partida|
|data_chegada|dateTime|Data de chegada|
|lotacao|int|Numero de passageiros que vai no voo|
|capacidade|int|Capacidade máxima para o voo|
|estado|ENUM|Se o voo foi cancelado, atrasado ou normal|
|companhia_id|int|id da companhia aérea|

#### Tabela Companhia

|Campo|Tipo de Dados|Descrição|
|---|---|---|
|companhia_id|int|id da companhia aérea|
|descricao|nvarchar(30)|Nome da companhia|
