@echo off
echo Building QuanLyKhachSan...
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" QuanLyKhachSan.sln /p:Configuration=Debug /p:Platform="Any CPU"
if %ERRORLEVEL% == 0 (
    echo.
    echo ✅ Build successful!
    echo Executable: QuanLyKhachSan\bin\Debug\QuanLyKhachSan.exe
) else (
    echo.
    echo ❌ Build failed!
)
pause