# sbgt

# Local Dev Database Setup
- Install Psql
- Run the following query against your instance:
```
CREATE ROLE taggserver LOGIN PASSWORD 'Q6%5nWgeN4#9';
CREATE SCHEMA taggserver AUTHORIZATION taggserver;
GRANT USAGE ON SCHEMA taggserver TO PUBLIC;
ALTER USER taggserver CREATEDB;
```