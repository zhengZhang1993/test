using Newtonsoft.Json;
using System.Text;

CreateJson();

 void CreateJson()
{
    Console.WriteLine("Please enter the enum value to create the data.(0:LOAInfo,1:CETLOAInfo,2:PET Module,3:PFP Module,4:CETModule,5:PET Module Catalog,6 PFP Module Catalog)");
    var type = Console.ReadLine();
    Console.WriteLine("Please enter the data count.");
    var countString = Console.ReadLine();
    int.TryParse(countString, out var count);
    switch (type)
    {
        case "0":
            if (type == "0")
            {
                string jsonPath = "C:\\data\\item\\stuloa.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<LOAInfo>>(json);
                var list = new List<LOAInfo>();
                for (int i = 0; i < count; i++)
                {
                    var LOAAppIds = DateTime.Now.Date.ToString("yyyyMMdd") + i.ToString();

                    int.TryParse(LOAAppIds, out var lOAAppId);
                    list.Add(new LOAInfo
                    {
                        LOAAppId = lOAAppId,
                        StudentId = data[0].StudentId,
                        StartDate = DateTime.Now.Date.AddDays(i),
                        EndDate = DateTime.Now.Date.AddDays(i + 1),
                        AppliedDate = DateTime.Now.Date.AddDays(-1),
                        Status = data[0].Status,
                        Comments = $"{data[0].StudentId} loa date is {DateTime.Now.Date.AddDays(i)} to {DateTime.Now.Date.AddDays(i + 1)}",
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\stuloa{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }

            break;
        case "1":
            if (type == "1")
            {
                var jsonPath = "C:\\data\\cet\\cetloa.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<CETLOAInfo>>(json);
                var list = new List<CETLOAInfo>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new CETLOAInfo
                    {
                        RequestId = Guid.NewGuid(),
                        StudentID = data[0].StudentID,
                        StartDate = DateTime.Now.Date.AddDays(i),
                        EndDate = DateTime.Now.Date.AddDays(i + 1),
                        Result = data[0].Result,
                        Comment = $"{data[0].StudentID} loa date is {DateTime.Now.Date.AddDays(i)} to {DateTime.Now.Date.AddDays(i + 1)}",
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\cet\\testdata\\cetloa{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }

            break;
        case "2":
            if (type == "2")
            {
                var jsonPath = "C:\\data\\item\\moduleoffersemester.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<ModuleOfferSemester>>(json);
                var list = new List<ModuleOfferSemester>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new ModuleOfferSemester
                    {
                        ModuleId = $"TEST_Module_PET_{i}",
                        ModuleCode = $"TEST_Module_PET_{i}",
                        SemesterNumber = data[0].SemesterNumber,
                        SchoolName = data[0].SchoolName,
                        SemesterCode = data[0].SemesterCode,
                        AcademicYear = data[0].AcademicYear,
                        Action = data[0].Action,
                        CoModuleManager = data[0].CoModuleManager,
                        LastUpdateDttm = data[0].LastUpdateDttm,
                        ModuleManager = data[0].ModuleManager,
                        ModuleOfferNumber = data[0].ModuleOfferNumber,
                        QualificationType = data[0].QualificationType,
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\petmoduleoffersemester{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }
            break;
        case "3":
            if (type == "3")
            {
                var jsonPath = "C:\\data\\item\\moduleoffersemester.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<ModuleOfferSemester>>(json);
                var list = new List<ModuleOfferSemester>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new ModuleOfferSemester
                    {
                        ModuleId = $"TEST_Module_PFP_{i}",
                        ModuleCode = $"TEST_Module_PFP_{i}",
                        SemesterNumber = data[1].SemesterNumber,
                        SchoolName = data[1].SchoolName,
                        SemesterCode = data[1].SemesterCode,
                        AcademicYear = data[1].AcademicYear,
                        Action = data[1].Action,
                        CoModuleManager = data[1].CoModuleManager,
                        LastUpdateDttm = data[1].LastUpdateDttm,
                        ModuleManager = data[1].ModuleManager,
                        ModuleOfferNumber = data[1].ModuleOfferNumber,
                        QualificationType = data[1].QualificationType,
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\pfpmoduleoffersemester{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }
            break;
        case "4":
            if (type == "4")
            {
                var jsonPath = "C:\\data\\cet\\cetmodule.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<CETModule>>(json);
                var list = new List<CETModule>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new CETModule
                    {
                        ModuleId = $"TEST_Module_CET_{i}",
                        ModuleCode = $"TEST_Module_CET_{i}",
                        SemesterNumber = data[0].SemesterNumber,
                        ModuleName = $"TEST_Module_CET_{i}",
                        SemesterCode = data[0].SemesterCode,
                        AcademicYear = data[0].AcademicYear,
                        Action = data[0].Action,
                        CreateDate = data[0].CreateDate,
                        ModuleSchool = data[0].ModuleSchool,
                        QualificationType = data[0].QualificationType,
                        Status = data[0].Status,
                        ModifiedOn = data[0].ModifiedOn,
                        ModuleCredits = data[0].ModuleCredits,
                        ModuleOffer = data[0].ModuleOffer,
                        ModuleOwner = data[0].ModuleOwner,
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\cet\\testdata\\cetmodule{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }
            break;
        case "5":
            if (type == "5")
            {
                var jsonPath = "C:\\data\\item\\moduleoffer.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<ModuleOffer>>(json);
                var list = new List<ModuleOffer>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new ModuleOffer
                    {
                        ModuleId = $"TEST_Module_PET_{i}",
                        ModuleCode = $"TEST_Module_PET_{i}",
                        Action = data[0].Action,
                        LastUpdateDttm = data[0].LastUpdateDttm,
                        ModuleOfferNumber = data[0].ModuleOfferNumber,
                        QualificationType = data[0].QualificationType,
                        AcademicOrganisation = data[0].AcademicOrganisation,
                        EffectiveDate = data[0].EffectiveDate,
                        Institution = data[0].Institution,
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\petmoduleoffer{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }

            if (type == "5")
            {
                var jsonPath = "C:\\data\\item\\module.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<Module>>(json);
                var list = new List<Module>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new Module
                    {
                        ModuleId = $"TEST_Module_PET_{i}",
                        Action = data[0].Action,
                        LastUpdateDttm = data[0].LastUpdateDttm,
                        EffectiveDate = data[0].EffectiveDate,
                        EffectiveStatus = data[0].EffectiveStatus,
                        ClassComponent = data[0].ClassComponent,
                        GradingBasis = data[0].GradingBasis,
                        MaximumCreditUnit = data[0].MaximumCreditUnit,
                        MinimumCreditUnit = data[0].MinimumCreditUnit,
                        ModuleDescription = data[0].ModuleDescription,
                        ModuleLongTitle = $"TEST_Module_PET_{i}",
                        ModuleTitle = $"TEST_Module_PET_{i}",
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\petmodule{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }
            break;
        case "6":
            if (type == "6")
            {
                var jsonPath = "C:\\data\\item\\moduleoffer.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<ModuleOffer>>(json);
                var list = new List<ModuleOffer>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new ModuleOffer
                    {
                        ModuleId = $"TEST_Module_PFP_{i}",
                        ModuleCode = $"TEST_Module_PFP_{i}",
                        Action = data[0].Action,
                        LastUpdateDttm = data[0].LastUpdateDttm,
                        ModuleOfferNumber = data[0].ModuleOfferNumber,
                        QualificationType = data[0].QualificationType,
                        AcademicOrganisation = data[0].AcademicOrganisation,
                        EffectiveDate = data[0].EffectiveDate,
                        Institution = data[0].Institution,
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\pfpmoduleoffer{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }

            if (type == "6")
            {
                var jsonPath = "C:\\data\\item\\module.json";
                string json = File.ReadAllText(jsonPath);
                var data = JsonConvert.DeserializeObject<List<Module>>(json);
                var list = new List<Module>();
                for (int i = 0; i < count; i++)
                {
                    list.Add(new Module
                    {
                        ModuleId = $"TEST_Module_PFP_{i}",
                        Action = data[0].Action,
                        LastUpdateDttm = data[0].LastUpdateDttm,
                        EffectiveDate = data[0].EffectiveDate,
                        EffectiveStatus = data[0].EffectiveStatus,
                        ClassComponent = data[0].ClassComponent,
                        GradingBasis = data[0].GradingBasis,
                        MaximumCreditUnit = data[0].MaximumCreditUnit,
                        MinimumCreditUnit = data[0].MinimumCreditUnit,
                        ModuleDescription = data[0].ModuleDescription,
                        ModuleLongTitle = $"TEST_Module_PFP_{i}",
                        ModuleTitle = $"TEST_Module_PFP_{i}",
                    });
                }

                try
                {
                    var jsonString = JsonConvert.SerializeObject(list);

                    string jsonPath2 = $"C:\\data\\item\\testdata\\pfpmodule{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

                    // 将对象转换为JSON字符串

                    // 打开或创建指定路径的文本文件以进行写入
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(jsonPath2))
                    {
                        // 将JSON数据写入文件
                        file.Write(jsonString);

                        Console.WriteLine("成功将数据写入到JSON文件！");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发生错误：{ex.Message}");
                }
            }
            break;
        default:
            break;
    }

    CreateJson();
}
public class CETLOAInfo
{
    public enum LOAStatus
    {
        A,
        R,
        D
    }

    public Guid RequestId { get; set; }

    public string StudentID { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Comment { get; set; }

    public LOAStatus Result { get; set; }
}

public class LOAInfo
{
    public enum LOAStatus
    {
        A,
        D,
        P,
        R,
        S
    }

    public int LOAAppId { get; set; }

    public string StudentId { get; set; }

    public DateTime AppliedDate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Comments { get; set; }

    public DateTime ModifiedDate { get; set; }

    public LOAStatus Status { get; set; }
}

public class ModuleOfferSemester
{
    public enum AuditAction
    {
        C,
        U,
        D
    }

    public string ModuleId { get; set; }

    public string ModuleOfferNumber { get; set; }

    public string QualificationType { get; set; }

    public string SchoolName { get; set; }

    public string SemesterCode { get; set; }

    public string SemesterNumber { get; set; }

    public string AcademicYear { get; set; }

    public string ModuleCode { get; set; }

    public string ModuleManager { get; set; }

    public string CoModuleManager { get; set; }

    public DateTime LastUpdateDttm { get; set; }

    public AuditAction Action { get; set; }
}

public class CETModule
{
    public enum RecordEffectiveStatus
    {
        A,
        I
    }

    public enum AuditAction
    {
        C,
        U,
        D
    }

    public string ModuleId { get; set; }

    public string ModuleCode { get; set; }

    public int ModuleOffer { get; set; }

    public DateTime CreateDate { get; set; }

    public RecordEffectiveStatus Status { get; set; }

    public string ModuleName { get; set; }

    public string ModuleCredits { get; set; }

    public string ModuleSchool { get; set; }

    public string QualificationType { get; set; }

    public string SemesterCode { get; set; }

    public string SemesterNumber { get; set; }

    public string AcademicYear { get; set; }

    public string ModuleOwner { get; set; }

    public DateTime ModifiedOn { get; set; }

    public AuditAction Action { get; set; }
}

public class ModuleOffer
{
    public enum AuditAction
    {
        C,
        U,
        D
    }

    public string ModuleId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public int ModuleOfferNumber { get; set; }

    public string Institution { get; set; }

    public string ModuleCode { get; set; }

    public string QualificationType { get; set; }

    public string AcademicOrganisation { get; set; }

    public DateTime LastUpdateDttm { get; set; }

    public AuditAction Action { get; set; }
}

public class Module
{
    public enum RecordEffectiveStatus
    {
        A,
        I
    }

    public enum AuditAction
    {
        C,
        U,
        D
    }

    public string ModuleId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public RecordEffectiveStatus EffectiveStatus { get; set; }

    public string ModuleTitle { get; set; }

    public string MinimumCreditUnit { get; set; }

    public string MaximumCreditUnit { get; set; }

    public string GradingBasis { get; set; }

    public string ModuleLongTitle { get; set; }

    public string ModuleDescription { get; set; }

    public string ClassComponent { get; set; }

    public DateTime LastUpdateDttm { get; set; }

    public AuditAction Action { get; set; }
}