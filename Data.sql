CREATE PROCEDURE UpdateScore
    @ID INT,
    @BlueScore INT = NULL,
    @RedScore INT = NULL,
    @YellowScore INT = NULL,
    @GreenScore INT = NULL
AS
BEGIN
    -- Kiểm tra nếu bản ghi có ID tồn tại
    IF EXISTS (SELECT 1 FROM ChartScore WHERE ID = @ID)
    BEGIN
        -- Thực hiện cập nhật
        UPDATE ChartScore
        SET
            BlueScore = COALESCE(@BlueScore, BlueScore),
            RedScore = COALESCE(@RedScore, RedScore),
            YellowScore = COALESCE(@YellowScore, YellowScore),
            GreenScore = COALESCE(@GreenScore, GreenScore)
        WHERE ID = @ID;
    END
    ELSE
    BEGIN
        -- Nếu ID không tồn tại, có thể trả về lỗi hoặc thông báo
        PRINT 'ID không tồn tại trong bảng ChartScore.';
    END
END;
GO


CREATE PROCEDURE [InsertScore]
    @ID INT OUTPUT,
    @BlueScore INT,
    @RedScore INT,
    @YellowScore INT,
    @GreenScore INT
AS
BEGIN
    -- Thêm bản ghi mới vào bảng ChartScore
    INSERT INTO ChartScore (BlueScore, RedScore, YellowScore, GreenScore)
    VALUES (@BlueScore, @RedScore, @YellowScore, @GreenScore);

    -- Lấy ID vừa tạo và gán vào tham số @ID
    SET @ID = SCOPE_IDENTITY();
END;
GO

Create Table ChartScore
(
	[ID] [int] IDENTITY(1,1) NOT NULL,
	BlueScore INT,
    RedScore INT,
    YellowScore INT,
    GreenScore INT
);

Select * 
From ChartScore
