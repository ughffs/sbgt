# sbgt

# Local Dev Database Setup
- Install Psql
- Run the following query against your instance:
```
CREATE ROLE sbgtserver LOGIN PASSWORD 'Q6%5nWgeN4#9';
CREATE SCHEMA sbgtserver AUTHORIZATION sbgtserver;
GRANT USAGE ON SCHEMA sbgtserver TO PUBLIC;
ALTER USER sbgtserver CREATEDB;
```