-- SCHEMA VERSION 14: 2021-05-08 --
-- Add per server system tag override--


alter table system_guild add column tag text default null;

update info set schema_version = 14;
