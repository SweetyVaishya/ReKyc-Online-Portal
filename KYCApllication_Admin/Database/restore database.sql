RESTORE FILELISTONLY FROM DISK='F:\DISK1\live database\AbyudayaDB_31_1_2023.BAK'



RESTORE DATABASE Abhyudaya FROM DISK='F:\DISK1\live database\AbyudayaDB_31_1_2023.BAK'
WITH MOVE 'Db_Abhudaya2018' TO 'F:\DISK1\DataFiles\MDF\Abhyudaya.MDF',
MOVE 'Db_Abhudaya2018_log' TO 'F:\DISK1\DataFiles\MDF\Abhyudaya.LDF', replace, STATS=1