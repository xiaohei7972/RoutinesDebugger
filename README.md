# HearthBuddyRoutinesDebugger

〖炉石兄弟策略调试软件〗源码，学习 C#，不可用于商业用途和非法牟利。

## 当前兼容版本

三个 C# 工具支持 Windows x64、.NET 8，以及安装目录中使用 Hearthbuddy.dll、lib 和 Routines/DefaultRoutine/Silverfish 的炉石兄弟版本。使用当前安装中的策略源码和卡牌数据进行离线调试。

本次适配基于所提供的 HB1.7.1 发布目录与 Hearthbuddy_Refactor 源码。历史 .NET Framework 4.7.2、x86 程序集需要使用对应历史版本的调试器。

## 使用发布包

1. 安装 .NET 8 Desktop Runtime x64，将发布包完整解压到可写目录。
2. 打开 RoutineCompiler.exe，点击设置按钮，选择炉石兄弟安装目录中的 DefaultRoutine 或其中的 Silverfish 子目录。
3. 点击重新编译 AI，检查编译诊断，再点击启动策略编辑器。
4. 在编辑器中选择策略和局面记录，执行测试，查看评分、动作和局面。卡牌查询支持输入关键字后按回车。

也可以直接打开 RoutineHelper.exe。首次启动会显示路径与编译窗口，后续启动加载已编译策略。修改策略后可通过界面重新编译。

配置保存在程序旁的 Settings/Default/routine.xml，沿用 RoutinePath、SilverfishPath、LastRoutine 和 LastTestFile。程序也支持 HB_DEFAULTROUTINE_PATH、HB_SILVERFISH_PATH、ROUTINEHELPER_DEFAULTROUTINE_PATH 环境变量，已有有效配置优先使用。与炉石兄弟放在相邻层级时可自动发现策略目录。

运行依赖从选定安装目录及其 lib 中读取。主程序集须为可加载的 Hearthbuddy.dll。缺失依赖时，请核对完整安装目录和错误信息中的文件路径。

## 命令行

在发布包目录中执行。相对输入路径以命令启动目录为基准。

```powershell
./RoutineHelper.exe --compile 'D:/炉石兄弟/Routines/DefaultRoutine'
./RoutineHelper.exe --run-test 'D:/炉石兄弟/Logs/Data/对局记录/牌面.txt' '丨通用丨不设惩罚'
./RoutineHelper.exe --run-latest-test '丨通用丨不设惩罚'
./ReflectionCodeGenerator.exe './CompiledAssemblies/Silverfish.dll' './GeneratedWrappers'
```

命令行重定向输出或等待退出时，也可以使用 dotnet RoutineHelper.dll 加相同参数。编译成功会保存策略目录配置。回放省略策略名称时采用已保存选择，再回退到首个可用策略。

RoutineHelper 退出码为 0 成功，1 编译或运行失败，2 参数或路径无效，3 未找到策略，4 策略类型缺失。生成器退出码为 0 成功，1 加载或生成失败，2 参数数量错误。

编译结果保存在 CompiledAssemblies/Silverfish.dll，包含嵌入式调试符号。编译日志为 compile_attempt.log，命令行回放记录为 cli_test.log，算法日志位于 Logs。编译失败保留上次成功程序集，同一路径上的并发编译会串行执行。

ReflectionCodeGenerator 读取指定策略程序集并生成包装类、所需枚举及 ReflectionHelper.cs。先配置策略目录，或设置 HB_DEFAULTROUTINE_PATH，以便解析炉石兄弟依赖。生成器会报告缺失类型和包装签名冲突，保留同一映射签名的首个方法。枚举通过名称转换。

旧局面记录中的省略字段会在输入阶段转换。缺少随从卡牌 ID 的历史格式通过当前 CardDB 的中文名称映射恢复，采用卡牌数据库的默认版本。历史日志缺失的变体信息会影响回放精度。优先使用包含卡牌 ID 的完整记录或 ENTITY_SNAPSHOT。

## 从源码构建

需要 Windows x64 和 .NET 8 SDK。开发依赖通过 NuGet 恢复。

```powershell
dotnet build RoutinesDebugger.sln -c Release
dotnet run --project tests/EditorSmoke -c Release
./scripts/publish.ps1
```

发布脚本生成 artifacts/RoutinesDebugger-win-x64 和同名 ZIP。输出目录需为新目录，也可使用 -OutputDirectory 指定其他位置。发布包包含三个工具及开发依赖，运行时读取所选炉石兄弟安装。

完整策略检查使用实际安装路径执行 --compile，再执行局面回放。现有完整策略编译后，还可以运行以下检查。

```powershell
dotnet run --project tests/EditorSmoke -c Release -- './artifacts/RoutinesDebugger-win-x64' 'D:/炉石兄弟'
dotnet run --project tests/UiSmoke -c Release -- './artifacts/RoutinesDebugger-win-x64' 'D:/炉石兄弟' 'D:/牌面.txt' -1893
```

UiSmoke 使用“丨通用丨不设惩罚”策略，最后一个参数为同一局面的 CLI 预期分数，所选局面须产生至少两个动作并包含敌方随从。检查覆盖 XAML 加载、界面回放、评分一致性、完整动作展示、卡牌查询和独立编译器启动编辑器。它会打开并关闭测试窗口，在测试输出目录保存配置。

Windows CI 构建三个工具和测试程序，运行合成程序集回归检查并提供 ZIP 构建产物。本地完整验证还需要炉石兄弟安装、策略源码和对局记录。

## 实现说明

RoutineHelper 与 RoutineCompiler 共用 Roslyn 编译服务、安装目录解析和输出目录。当前策略中的 APPLICATION_MODE 回调由编辑器承接，离线 TestBase 兼容入口接入当前 BoardTester。MainWindow 与 CompilerWindow 均由可编辑 XAML 构建。缺少的可选内核状态显示为“内核未提供”，超级风怒、攻击力和圣盾别名映射到当前字段。

HB相关调整示例保留原版示例，修改策略时须结合当前源码接口。
