# Biblioteca MVC - Tutorial de Configuração do MySQL

Seja bem-vindo ao projeto da Biblioteca Digital! Como estamos integrando o banco de dados agora, você precisará configurar o MySQL localmente na sua máquina para rodar o projeto pela primeira vez.

## Passo a Passo para Configurar o MySQL Workbench e o Banco de Dados

1. **Abra o MySQL Workbench:**
   - Inicie o MySQL Workbench que você acabou de instalar.
   - Clique na conexão local existente (geralmente chamada de "Local instance 3306") ou crie uma nova clicando no botão `+` ao lado de "MySQL Connections".

2. **Crie a Conexão (Se necessário):**
   - **Connection Name:** Pode ser "ConexaoBiblioteca"
   - **Hostname:** `127.0.0.1` ou `localhost`
   - **Port:** `3306`
   - **Username:** `root`
   - Clique em "Test Connection" e insira a senha que você configurou durante a instalação do MySQL.

3. **Configuração do Usuário e Banco para o Projeto:**
   - No projeto, o arquivo `appsettings.json` está configurado para usar o usuário `root` e a senha `teste123`, e o banco de dados se chama `BibliotecaDb`.
   - Para garantir que tudo funcione, você precisa ter essa mesma senha ou alterar a senha no arquivo `appsettings.json` para a sua senha real do MySQL.
   - Abra uma nova aba de "Query" (consulta) no MySQL Workbench clicando no ícone "Create a new SQL tab".
   - **Copie e cole o comando abaixo** para criar o banco de dados e garantir os privilégios (Altere 'teste123' se a sua senha for diferente):

   ```sql
   CREATE DATABASE IF NOT EXISTS BibliotecaDb;
   ALTER USER 'root'@'localhost' IDENTIFIED BY 'teste123';
   GRANT ALL PRIVILEGES ON BibliotecaDb.* TO 'root'@'localhost';
   FLUSH PRIVILEGES;
   ```

   - Clique no ícone de **raio** (Execute the selected portion of the script) para rodar o comando.

4. **Rodando as Migrations no Visual Studio / Terminal:**
   - Com o banco configurado no MySQL Workbench, agora precisamos criar as tabelas (Livros e Autores).
   - Abra o terminal na pasta raiz do projeto `Biblioteca` (onde está o arquivo `Biblioteca.csproj`).
   - Execute o comando para criar as tabelas no seu MySQL:
     ```bash
     dotnet ef database update --context BibliotecaContext
     ```

5. **Execute o Projeto:**
   - No terminal, rode:
     ```bash
     dotnet run
     ```
   - O projeto agora vai abrir no navegador com o banco de dados totalmente configurado e conectado!
