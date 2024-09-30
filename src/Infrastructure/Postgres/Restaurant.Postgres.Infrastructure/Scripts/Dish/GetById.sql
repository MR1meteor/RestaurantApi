SELECT
    id              as "Id",
    name            as "Name",
    description     as "Description",
    category        as "Category",
    is_available    as "IsAvailable"
FROM dishes
WHERE id = @Id