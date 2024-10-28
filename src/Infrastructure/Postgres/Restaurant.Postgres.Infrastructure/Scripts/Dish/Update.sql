UPDATE dishes
SET name         = @Name,
    description  = @Description,
    category     = @Category,
    is_available = @IsAvailable
WHERE id = @Id