//using Aurora.Claims.Test.TestDataFolder;
//using Aurora.Claims.Test.PageObjects;
//using Aurora.Claims.Test.GenericClasses;
//using AventStack.ExtentReports;
//using OpenQA.Selenium;
//using OpenQA.Selenium.IE;
//using System;
//using System.Linq;
//using System.Threading;
//using System.Configuration;
//using OpenQA.Selenium.Interactions;
//using System.Diagnostics;
//using OpenQA.Selenium.Support.UI;
//using System.Collections.Generic;
//using SeleniumExtras.WaitHelpers;
//using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

//namespace Aurora.Claims.Test.TestCases
//{
//    class Claim
//    {
//        public static void claim_closure(string path)
//        {

//            ExcelUtil.PopulateInCollection(path, ConfigurationManager.AppSettings["Before_Sheetname"]);
//            ExcelVerify.PopulateInCollection(path, ConfigurationManager.AppSettings["After_Sheetname"]);
//            ExcelUtil.CreateFileOrFolder(ExcelUtil.ReadData(1, "Test_Folder_Name"));
//            AppDriver.test = AppDriver.extent.CreateTest(ExcelUtil.ReadData(1, "Claim_Description"));
//            AppDriver.test.Log(Status.Info, ExcelUtil.ReadData(1, "Case_Info"));
            //String userProfile = "C:\\Users\\ramkumar.r\\AppData\\Local\\Google\\Chrome\\User Data\\";
            //ChromeOptions options = new ChromeOptions();
            //options.AddArguments("--user-data-dir=" + userProfile);
            //options.AddArguments("--profile-directory=Default");
            //options.AddArguments("--start-maximized");

            //String userProfile1 = "C:\\Users\\ramkumar.r\\AppData\\Local\\Google\\Chrome\\User Data\\";
            //FirefoxOptions options1 = new FirefoxOptions();
            //options.AddArguments("--user-data-dir=" + userProfile1);
            //options.AddArguments("--profile-directory=Default");
            //options.AddArguments("--start-maximized");


            //String userProfile2 = "C:\\Users\\ramkumar.r\\AppData\\Local\\Microsoft\\Internet Explorer\\";
            //InternetExplorerOptions options2 = new InternetExplorerOptions();
            //options.AddArguments("--user-data-dir=" + userProfile2);
            //options.AddArguments("--profile-directory=Default");
            //options.AddArguments("--start-maximized"); 

//            try
//            {
//                // Create the in stance of IE
//                AppDriver.driver = new InternetExplorerDriver();
//                AppDriver.driver.Manage().Window.Maximize();
//                WebDriverWait waitone = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));

//                //url To launch the application
//                AppDriver.driver.Url = ConfigurationManager.AppSettings["URL"];

//                //Process to enter credentials in windows security dialog box
//                Process p = new Process();
//                p.StartInfo.FileName = ConfigurationManager.AppSettings["CredentialsLocation"] + ConfigurationManager.AppSettings["Dev_LoginLevel1"];
//                p.Start();
//                Thread.Sleep(20000);

//                //Navigate to claim screen
//                AppDriver.page = new CreateClaimPage();
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();

//                //Second level authentication
//                p = new Process();
//                p.StartInfo.FileName = ConfigurationManager.AppSettings["CredentialsLocation"] + ConfigurationManager.AppSettings["Dev_LoginLevel2"];
//                p.Start();
//                Thread.Sleep(10000);

//                //To get the parent window
//                AppDriver.ParentWindow = AppDriver.driver.CurrentWindowHandle;
//                Thread.Sleep(2000);

//                AppDriver.test.Log(Status.Pass, "Step 1 : Login to the application is Successfull");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step1.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step1.png").Build());//.png"

//                //Switch to Claims detail frame
//                AppDriver.driver.SwitchTo().Frame("IFrmApplication");
//                Thread.Sleep(2000);
//                //To get the Child window
//                AppDriver.ChildWindow = AppDriver.driver.CurrentWindowHandle;

//                //Navigate to search claim page
//                AppDriver.spage = new SearchClaimPage();
//                //Search for claim number
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimNumber));
//                AppDriver.spage.srhClaimNumber.SendKeys(ExcelUtil.ReadData(1, "ClaimNumber"));
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimbtn));
//                AppDriver.spage.srhClaimbtn.Click();
//                Thread.Sleep(2000);
//                try
//                {
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    ex.Message.ToString();
//                }
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.past_claim_manager));
//                var claim_manager = AppDriver.spage.past_claim_manager.gettext();
//                string value = claim_manager.Trim();
//                if (value != ExcelUtil.ReadData(1, "Approval_Manager"))
//                {
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.Edit_Case_Details));
//                    AppDriver.spage.Edit_Case_Details.Click();
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.claim_manager));
//                    AppDriver.spage.claim_manager.selectdropdowntext(ExcelUtil.ReadData(1, "Approval_Manager"));
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.save_claim_manager));
//                    AppDriver.spage.save_claim_manager.Click();
//                }

//                try
//                {
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    ex.Message.ToString();
//                }

//                AppDriver.test.Log(Status.Pass, "Step 2 : Search claim is Successfull");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step2.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step2.png").Build());

//                AppDriver.spage = new SearchClaimPage();
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.claimstatus));
//                var claimstatus = AppDriver.spage.claimstatus.Text;
//                //Navigate to reserver progress screen

//                if (claimstatus == "Re-Activated")
//                {
//                    AppDriver.rpage = new ReservePage();
//                    Actions action180 = new Actions(AppDriver.driver);
//                    IWebElement ReOpen2 = AppDriver.rpage.Reserve;
//                    action180.MoveToElement(ReOpen2).Build().Perform();
//                    //Thread.Sleep(3000);
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.Progress));
//                    AppDriver.rpage.Progress.Click();
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.EditProgress));
//                    AppDriver.rpage.EditProgress.Click();
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ddlCaseStatus));
//                    AppDriver.rpage.ddlCaseStatus.selectdropdownvalue("C");
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.SaveProgress));
//                    AppDriver.rpage.SaveProgress.Click(); //*[@id="imgsave"]

//                    try
//                    {
//                        //Check the presence of alert
//                        IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                        // if present consume the alert
//                        aler.Accept();
//                    }
//                    catch (NoAlertPresentException ex)
//                    {
//                        // Alert not present
//                        ex.Message.ToString();
//                    }
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                    AppDriver.rpage.ImgSavGo.Click();
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                    AppDriver.rpage.ImgSavGo.Click();
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                    AppDriver.rpage.ImgSavGo.Click();
//                    waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                    AppDriver.rpage.ImgSavGo.Click();
//                }
//                AppDriver.rpage = new ReservePage();
//                //Navigate to reserver progress screen
//                Actions action1 = new Actions(AppDriver.driver);
//                IWebElement ReOpen = AppDriver.rpage.Reserve;
//                action1.MoveToElement(ReOpen).Build().Perform();
//                // Thread.Sleep(3000);
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.Progress));
//                AppDriver.rpage.Progress.Click();
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.EditProgress));
//                AppDriver.rpage.EditProgress.Click();
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ddlCaseStatus));
//                AppDriver.rpage.ddlCaseStatus.selectdropdownvalue("R");
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.SaveProgress));
//                AppDriver.rpage.SaveProgress.Click();
//                waitone.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.CloseProgress));
//                AppDriver.rpage.CloseProgress.Click();
//                Thread.Sleep(2000);

//                //Confirm the alert
//                try
//                {
//                    //Check the presence of alert
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    // if present consume the alert
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    // Alert not present
//                    ex.Message.ToString();
//                }

//                AppDriver.test.Log(Status.Pass, "Step 3 : ReActivated successfully and waiting for Second level Authorizationan");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step3.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step3.png").Build());
//                AppDriver.driver.Close();


//                AppDriver.driver = new InternetExplorerDriver();
//                AppDriver.driver.Manage().Window.Maximize();
//                WebDriverWait waitsecond = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));
//                //url To launch the application
//                AppDriver.driver.Url = ConfigurationManager.AppSettings["URL"];

//                // Process to enter credentials in windows security dialog box
//                Process p1 = new Process();
//                p1.StartInfo.FileName = ConfigurationManager.AppSettings["CredentialsLocation"] + ConfigurationManager.AppSettings["Dev_LoginLevel3"];
//                p1.Start();
//                Thread.Sleep(20000);

//                //Navigate to claim screen
//                AppDriver.page = new CreateClaimPage();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();

//                //Second level authentication
//                p1 = new Process();
//                p1.StartInfo.FileName = ConfigurationManager.AppSettings["CredentialsLocation"] + ConfigurationManager.AppSettings["Dev_LoginLevel4"];
//                p1.Start();
//                Thread.Sleep(10000);

//                //Capture the parent window instance
//                AppDriver.ParentWindow2 = AppDriver.driver.CurrentWindowHandle;

//                AppDriver.test.Log(Status.Pass, "Step 4 : Approval Manager Logged in Successfully");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step4.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step4.png").Build());

//                if (AppDriver.driver.FindElement(By.Id("IframeWorkflow")).Displayed)
//                {
//                    Console.WriteLine("diplayed");
//                }
//                else
//                {
//                    Console.WriteLine("Not diplayed");
//                    WorkFlow wpage1 = new WorkFlow();
//                    wpage1.OpenWorkflow.Click();
//                }

//                //Switch to Workflow frame
//                AppDriver.driver.SwitchTo().Frame(AppDriver.driver.FindElement(By.Id("IframeWorkflow")));
//                Thread.Sleep(2000);
//                //Naviagte to Workflow frame
//                WorkFlow wpage = new WorkFlow();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.workflowwindowDescription));
//                wpage.workflowwindowDescription.selectdropdownvalue("9800");
//                Thread.Sleep(3000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.status));
//                wpage.status.selectdropdowntext("Assigned");
//                Thread.Sleep(1000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.Assigned));
//                wpage.Assigned.selectdropdowntext(ExcelUtil.ReadData(1, "Approval_Manager"));
//                Thread.Sleep(1000);

//                string sRowvalue = ExcelUtil.ReadData(1, "ClaimNumber");

//                var elemTableone = AppDriver.driver.FindElement(By.XPath("//div[@id='tab_roi']/div/div/table[@id='ContentPlaceHolder1_tasks']"));

//                // Fetch all Row of the table
//                List<IWebElement> lstTrElemone = new List<IWebElement>(elemTableone.FindElements(By.TagName("tr")));
//                string strRowDataone = "";

//                // Traverse each row
//                foreach (var elemTrone in lstTrElemone)
//                {
//                    strRowDataone = strRowDataone + elemTrone.Text + "\t\t";
//                    if (strRowDataone.Contains(sRowvalue))
//                    {
//                        Actions action38 = new Actions(AppDriver.driver);
//                        IWebElement vvone = elemTrone;
//                        IAction dblClickone = action38.DoubleClick(vvone).Build();
//                        dblClickone.Perform();
//                        break;
//                    }
//                }
//                strRowDataone = string.Empty;

//                Thread.Sleep(5000);
//                AppDriver.driver.SwitchTo().Window(AppDriver.driver.WindowHandles.Last());
//                Thread.Sleep(2000);
//                //   Switch to Workflow frame
//                AppDriver.driver.SwitchTo().Frame(AppDriver.driver.FindElement(By.Id("frmchequescan")));
//                Thread.Sleep(2000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.ddlstaffname));
//                wpage.ddlstaffname.selectdropdowntext(ExcelUtil.ReadData(1, "Approval_Manager"));
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.save_staffname));
//                wpage.save_staffname.Click();
//                Thread.Sleep(2000);

//                AppDriver.driver.SwitchTo().Window(AppDriver.ParentWindow2);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();
//                Thread.Sleep(2000);

//                //Switch to Workflow frame
//                AppDriver.driver.SwitchTo().Frame(AppDriver.driver.FindElement(By.Id("IframeWorkflow")));
//                Thread.Sleep(2000);
//                //Naviagte to Workflow frame
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.workflowwindowDescription));
//                wpage.workflowwindowDescription.selectdropdownvalue("9801");
//                Thread.Sleep(2000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.status));
//                wpage.status.selectdropdowntext("Assigned");
//                Thread.Sleep(1000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.Assigned));
//                wpage.Assigned.selectdropdowntext(ExcelUtil.ReadData(1, "Approval_Manager"));
//                Thread.Sleep(1000);


//                var elemTabletwo = AppDriver.driver.FindElement(By.XPath("//div[@id='tab_roi']/div/div/table[@id='ContentPlaceHolder1_tasks']"));

//                // Fetch all Row of the table
//                List<IWebElement> lstTrElemtwo = new List<IWebElement>(elemTabletwo.FindElements(By.TagName("tr")));
//                string strRowDatatwo = "";

//                // Traverse each row
//                foreach (var elemTrtwo in lstTrElemtwo)
//                {
//                    strRowDatatwo = strRowDatatwo + elemTrtwo.Text + "\t\t";
//                    if (strRowDatatwo.Contains(sRowvalue))
//                    {
//                        Actions action28 = new Actions(AppDriver.driver);
//                        IWebElement vvtwo = elemTrtwo;
//                        IAction dblClicktwo = action28.DoubleClick(vvtwo).Build();
//                        dblClicktwo.Perform();
//                        break;
//                    }
//                }
//                strRowDatatwo = string.Empty;

//                Thread.Sleep(10000);
//                //Switch to Workflow frame
//                AppDriver.driver.SwitchTo().Frame("IFrmApplication");
//                Thread.Sleep(2000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(wpage.Authorise_Committee_Decision));
//                wpage.Authorise_Committee_Decision.Click();
//                Thread.Sleep(2000);
//                //Confirm the alert
//                IAlert s_alert1 = AppDriver.driver.SwitchTo().Alert();
//                s_alert1.Accept();


//                AppDriver.test.Log(Status.Pass, "Step 5 : Claim ReActivated and second level approval Successfully");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step5.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step5.png").Build());

//                AppDriver.driver.SwitchTo().Window(AppDriver.ParentWindow2);

//                //Navigate to claim screen
//                AppDriver.page = new CreateClaimPage();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();

//                //Switch to Claims detail frame
//                AppDriver.driver.SwitchTo().Frame("IFrmApplication");
//                Thread.Sleep(2000);
//                //Navigate to search claim page
//                AppDriver.spage = new SearchClaimPage();
//                //Search for claim number
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimNumber));
//                AppDriver.spage.srhClaimNumber.SendKeys(ExcelUtil.ReadData(1, "ClaimNumber"));
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimbtn));
//                AppDriver.spage.srhClaimbtn.Click();
//                Thread.Sleep(2000);

//                try
//                {
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    ex.Message.ToString();
//                }

//                AppDriver.test.Log(Status.Pass, "Step 6 : Search claim is Successfull");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step6.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step6.png").Build());


//                //Naviaget to reserve Screen
//                AppDriver.rpage = new ReservePage();
//                Actions action4 = new Actions(AppDriver.driver);
//                IWebElement Reserve = AppDriver.rpage.Reserve;
//                action4.MoveToElement(Reserve).Build().Perform();
//                //Thread.Sleep(2000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.IndemnityReserve));
//                AppDriver.rpage.IndemnityReserve.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ItyRsrEdit));
//                AppDriver.rpage.ItyRsrEdit.Click();
//                Thread.Sleep(2000);
//                try
//                {
//                    // Check the presence of alert
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    // Alert not present
//                    ex.Message.ToString();
//                }
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ddlEstimateType));
//                //Add value from Test data sheet to indemnity reserve screen
//                AppDriver.rpage.ddlEstimateType.selectdropdowntext(ExcelUtil.ReadData(8, "Past_Losses"));
//                Thread.Sleep(2000);
//                if (AppDriver.rpage.TotalDamages.Enabled)
//                {
//                    AppDriver.rpage.TotalDamages.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.TotalDamages.SendKeys(Keys.Delete);
//                    AppDriver.rpage.TotalDamages.SendKeys(ExcelUtil.ReadData(10, "Past_Losses")); //Past_Losses Future_Losses Legal_Cost

//                    AppDriver.rpage.Peconomicloss.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.Peconomicloss.SendKeys(Keys.Delete);
//                    AppDriver.rpage.Peconomicloss.SendKeys(ExcelUtil.ReadData(13, "Past_Losses"));

//                    AppDriver.rpage.PPocketExpense.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.PPocketExpense.SendKeys(Keys.Delete);
//                    AppDriver.rpage.PPocketExpense.SendKeys(ExcelUtil.ReadData(14, "Past_Losses"));

//                    AppDriver.rpage.PCareCost.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.PCareCost.SendKeys(Keys.Delete);
//                    AppDriver.rpage.PCareCost.SendKeys(ExcelUtil.ReadData(15, "Past_Losses"));

//                    AppDriver.rpage.Feconomicloss.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.Feconomicloss.SendKeys(Keys.Delete);
//                    AppDriver.rpage.Feconomicloss.SendKeys(ExcelUtil.ReadData(13, "Future_Losses"));

//                    AppDriver.rpage.FPocketExpense.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.FPocketExpense.SendKeys(Keys.Delete);
//                    AppDriver.rpage.FPocketExpense.SendKeys(ExcelUtil.ReadData(14, "Future_Losses"));

//                    AppDriver.rpage.FCareCost.SendKeys(Keys.Control + "a");
//                    AppDriver.rpage.FCareCost.SendKeys(Keys.Delete);
//                    AppDriver.rpage.FCareCost.SendKeys(ExcelUtil.ReadData(15, "Future_Losses"));
//                }

//                AppDriver.rpage.LegalCostsDisbursements.SendKeys(Keys.Control + "a");
//                AppDriver.rpage.LegalCostsDisbursements.SendKeys(Keys.Delete);
//                AppDriver.rpage.LegalCostsDisbursements.SendKeys(ExcelUtil.ReadData(13, "Legal_Cost"));

//                AppDriver.rpage.LegalClaimantCostsDisbursements.SendKeys(Keys.Control + "a");
//                AppDriver.rpage.LegalClaimantCostsDisbursements.SendKeys(Keys.Delete);
//                AppDriver.rpage.LegalClaimantCostsDisbursements.SendKeys(ExcelUtil.ReadData(14, "Legal_Cost"));

//                AppDriver.rpage.LegalInsuredReimbursements.SendKeys(Keys.Control + "a");
//                AppDriver.rpage.LegalInsuredReimbursements.SendKeys(Keys.Delete);
//                AppDriver.rpage.LegalInsuredReimbursements.SendKeys(ExcelUtil.ReadData(15, "Legal_Cost"));

//                AppDriver.rpage.LitigationRiskDiscount.SendKeys(Keys.Control + "a");
//                AppDriver.rpage.LitigationRiskDiscount.SendKeys(Keys.Delete);
//                string ttt = ExcelUtil.ReadData(20, "Legal_Cost");
//                double d_ttt = Convert.ToDouble(ttt);
//                double f_ttt = (d_ttt * 100);
//                string s_ttt = Convert.ToString(f_ttt);
//                AppDriver.rpage.LitigationRiskDiscount.SendKeys(s_ttt);
//                Thread.Sleep(2000);

//                if (AppDriver.rpage.ddlAddCosttType.Enabled)
//                {
//                    //other cost
//                    IWebElement E_Table = AppDriver.driver.FindElement(By.XPath("//div[@id='pnlAddition']/div[@id='dv-names-Addition']"));
//                    List<IWebElement> exist_table = new List<IWebElement>(E_Table.FindElements(By.TagName("table")));
//                    int table_count = exist_table.Count;
//                    if (table_count != 0)
//                    {
//                        var R_elemTable = AppDriver.driver.FindElement(By.XPath("//div[@id='pnlAddition']/div[@id='dv-names-Addition']/table"));
//                        // Fetch all Row of the table
//                        List<IWebElement> R_lstTrElem = new List<IWebElement>(R_elemTable.FindElements(By.TagName("tr")));
//                        int cnt = R_lstTrElem.Count;
//                        Console.WriteLine(cnt);
//                        int i;
//                        for (i = 1; i <= cnt; i++)
//                        {
//                            var R_elemTable1 = AppDriver.driver.FindElement(By.XPath("//div[@id='pnlAddition']/div[@id='dv-names-Addition']/table"));
//                            var R_elemTr = R_elemTable1.FindElement(By.TagName("tr"));
//                            var pp = R_elemTr.FindElement(By.XPath("//input[@title='Delete']"));
//                            pp.Click();
//                            R_elemTable1 = null;
//                            R_elemTr = null;
//                            pp = null;
//                        }
//                    }

//                    string a = ExcelUtil.ReadData(18, "Past_Losses");
//                    string b = ExcelUtil.ReadData(18, "Future_Losses");
//                    if ((a != "0") || (b != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(18, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(18, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(18, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                    string c = ExcelUtil.ReadData(19, "Past_Losses");
//                    string d = ExcelUtil.ReadData(19, "Future_Losses");
//                    if ((c != "0") || (d != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(19, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(19, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(19, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                    string e = ExcelUtil.ReadData(20, "Past_Losses");
//                    string f = ExcelUtil.ReadData(20, "Future_Losses");
//                    if ((e != "0") || (f != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(20, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(20, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(20, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                    string g = ExcelUtil.ReadData(21, "Past_Losses");
//                    string h = ExcelUtil.ReadData(21, "Future_Losses");
//                    if ((g != "0") || (h != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(21, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(21, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(21, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                    string k = ExcelUtil.ReadData(22, "Past_Losses");
//                    string l = ExcelUtil.ReadData(22, "Future_Losses");
//                    if ((k != "0") || (l != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(22, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(22, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(22, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                    string m = ExcelUtil.ReadData(23, "Past_Losses");
//                    string n = ExcelUtil.ReadData(23, "Future_Losses");
//                    if ((m != "0") || (n != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(23, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(23, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(23, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                    string o = ExcelUtil.ReadData(24, "Past_Losses");
//                    string q = ExcelUtil.ReadData(24, "Future_Losses");
//                    if ((o != "0") || (q != "0"))
//                    {
//                        AppDriver.rpage.ddlAddCosttType.selectdropdowntext(ExcelUtil.ReadData(24, "Add_Type"));
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtPAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtPAddCost.SendKeys(ExcelUtil.ReadData(24, "Past_Losses"));
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Control + "a");
//                        AppDriver.rpage.txtFAddCost.SendKeys(Keys.Delete);
//                        AppDriver.rpage.txtFAddCost.SendKeys(ExcelUtil.ReadData(24, "Future_Losses"));
//                        AppDriver.rpage.ImgAddBrkDownAddition.Click();
//                    }
//                }



//                //Insured values
//                IWebElement txtper = AppDriver.driver.FindElement(By.XPath("//div[@id='tab_roi']/table/tbody/tr/td/div[@id='dvNames']/table[@id='grdTimesheet1']/tbody/tr[3]/td[1]"));
//                if (txtper.Displayed)
//                {
//                    AppDriver.rpage = new ReservePage();
//                    AppDriver.driver.FindElement(By.XPath("//div[@id='tab_roi']/table/tbody/tr/td/div[@id='dvNames']/table[@id='grdTimesheet1']/tbody/tr[3]/td[1]")).Click();
//                    string tt = ExcelUtil.ReadData(24, "Legal_Cost");
//                    double d_tt = Convert.ToDouble(tt);
//                    double f_tt = (d_tt * 100);
//                    string s_tt = Convert.ToString(f_tt);
//                    waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.txtPercent));
//                    AppDriver.rpage.txtPercent.SendKeys(s_tt);
//                    waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.AddtxtPercent));
//                    AppDriver.rpage.AddtxtPercent.Click();
//                }
//                else
//                {
//                    AppDriver.rpage = new ReservePage();
//                    string tt = ExcelUtil.ReadData(24, "Legal_Cost");
//                    double d_tt = Convert.ToDouble(tt);
//                    double f_tt = (d_tt * 100);
//                    string s_tt = Convert.ToString(f_tt);
//                    waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.txtPercent));
//                    AppDriver.rpage.txtPercent.SendKeys(s_tt);
//                    waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.AddtxtPercent));
//                    AppDriver.rpage.AddtxtPercent.Click();
//                }

//                AppDriver.ChildWindow3 = AppDriver.driver.CurrentWindowHandle;

//                //Add commnents for reserve
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ItyRsrComments));
//                AppDriver.rpage.ItyRsrComments.SendKeys("Done3");
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ItyRsrsave));
//                AppDriver.rpage.ItyRsrsave.Click();
//                Thread.Sleep(4000);
//                AppDriver.driver.SwitchTo().Window(AppDriver.driver.WindowHandles.Last());
//                Thread.Sleep(4000);

//                Boolean Retryclick(By by)
//                {
//                    Boolean result = false;
//                    int attempts = 0;
//                    while (attempts < 5)
//                    {
//                        try
//                        {
//                            Actions act = new Actions(AppDriver.driver);
//                            WebDriverWait wait = new WebDriverWait(AppDriver.driver, TimeSpan.FromSeconds(70));
//                            IWebElement userclick = waitsecond.Until<IWebElement>(d => d.FindElement(by));
//                            act.MoveToElement(userclick).Click().Perform();
//                            //userclick.Click();
//                            Thread.Sleep(25000);
//                            AppDriver.driver.SwitchTo().Window(AppDriver.ChildWindow3);
//                            result = true;
//                            break;
//                        }
//                        catch (Exception e)
//                        {
//                            Console.WriteLine("exce" + e);
//                            result = false;
//                        }
//                        attempts++;
//                        Console.WriteLine("tried" + attempts);
//                    }
//                    Console.WriteLine("trtt" + result);
//                    return result;
//                }

//                Retryclick(By.XPath("//*[@id='Img2']"));
//                Thread.Sleep(2000);
//                AppDriver.driver.SwitchTo().Window(AppDriver.ChildWindow3);
//                try
//                {
//                    // Check the presence of alert
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();

//                }
//                catch (NoAlertPresentException ex)
//                {

//                    ex.Message.ToString();
//                }

//                AppDriver.test.Log(Status.Pass, "Step 7 : Indemnity Reserve added Successfull");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step7.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step7.png").Build());


//                AppDriver.driver.SwitchTo().Window(AppDriver.ParentWindow2);
//                Thread.Sleep(2000);
//                AppDriver.page = new CreateClaimPage();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();
//                Thread.Sleep(2000);
//                AppDriver.driver.SwitchTo().Frame("IFrmApplication");
//                Thread.Sleep(2000);
//                AppDriver.spage = new SearchClaimPage();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimNumber));
//                AppDriver.spage.srhClaimNumber.SendKeys(ExcelUtil.ReadData(1, "ClaimNumber"));
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimbtn));
//                AppDriver.spage.srhClaimbtn.Click();

//                try
//                {
//                    // Check the presence of alert
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    ex.Message.ToString();
//                }

//                //Navigate to reserver progress screen
//                AppDriver.rpage = new ReservePage();
//                Actions action190 = new Actions(AppDriver.driver);
//                IWebElement ReOpen1 = AppDriver.rpage.Reserve;
//                action190.MoveToElement(ReOpen1).Build().Perform();
//                //Thread.Sleep(2000);
//                AppDriver.rpage.Progress.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.EditProgress));
//                AppDriver.rpage.EditProgress.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ddlCaseStatus));
//                AppDriver.rpage.ddlCaseStatus.selectdropdownvalue("C");
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.driver.FindElement(By.XPath("//*[@id='imgsave']"))));
//                AppDriver.driver.FindElement(By.XPath("//*[@id='imgsave']")).Click();

//                try
//                {
//                    //Check the presence of alert
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    // if present consume the alert
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    // Alert not present
//                    ex.Message.ToString();
//                }
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                AppDriver.rpage.ImgSavGo.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                AppDriver.rpage.ImgSavGo.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                AppDriver.rpage.ImgSavGo.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.ImgSavGo));
//                AppDriver.rpage.ImgSavGo.Click();
//                Thread.Sleep(2000);
//                AppDriver.test.Log(Status.Pass, "Step 8 : Claim Closed successfully");
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step8.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step8.png").Build());

//                AppDriver.driver.SwitchTo().Window(AppDriver.ParentWindow2);
//                Thread.Sleep(2000);
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.page.lClaims));
//                AppDriver.page.lClaims.Click();
//                Thread.Sleep(2000);
//                AppDriver.driver.SwitchTo().Frame("IFrmApplication");
//                Thread.Sleep(2000);
//                AppDriver.spage = new SearchClaimPage();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimNumber));
//                AppDriver.spage.srhClaimNumber.SendKeys(ExcelUtil.ReadData(1, "ClaimNumber"));
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.spage.srhClaimbtn));
//                AppDriver.spage.srhClaimbtn.Click();
//                try
//                {
//                    // Check the presence of alert
//                    IAlert aler = AppDriver.driver.SwitchTo().Alert();
//                    aler.Accept();
//                }
//                catch (NoAlertPresentException ex)
//                {
//                    // Alert not present
//                    ex.Message.ToString();
//                }

//                //Navigate to verify indemnity values
//                AppDriver.rpage = new ReservePage();
//                Actions action78 = new Actions(AppDriver.driver);
//                IWebElement verify = AppDriver.rpage.Reserve;
//                action78.MoveToElement(verify).Build().Perform();
//                //Thread.Sleep(3000);
//                AppDriver.rpage.IndemnityReserve.Click();
//                waitsecond.Until(ExpectedConditions.ElementToBeClickable(AppDriver.rpage.TotalDamages));
//                Thread.Sleep(2000);
//                //Read value from indemnity reserve screen
//                //string EstimateType = rpage.ddlEstimateType.gettextfromDDL();
//                string vTotalDamages = AppDriver.rpage.TotalDamages.gettext();

//                string vPeconomicloss = AppDriver.rpage.Peconomicloss.gettext();
//                string vPPocketExpense = AppDriver.rpage.PPocketExpense.gettext();
//                string vPCareCost = AppDriver.rpage.PCareCost.gettext();

//                string vFeconomicloss = AppDriver.rpage.Feconomicloss.gettext();
//                string vFPocketExpense = AppDriver.rpage.FPocketExpense.gettext();
//                string vFCareCost = AppDriver.rpage.FCareCost.gettext();

//                string vLegalCostsDisbursements = AppDriver.rpage.LegalCostsDisbursements.gettext();
//                string vLegalClaimantCostsDisbursements = AppDriver.rpage.LegalClaimantCostsDisbursements.gettext();
//                string vLegalInsuredReimbursements = AppDriver.rpage.LegalInsuredReimbursements.gettext();

//                double d_vTotalDamages = Convert.ToDouble(vTotalDamages);
//                double d_vPeconomicloss = Convert.ToDouble(vPeconomicloss);
//                double d_vPPocketExpense = Convert.ToDouble(vPPocketExpense);
//                double d_vPCareCost = Convert.ToDouble(vPCareCost);

//                double d_vFeconomicloss = Convert.ToDouble(vFeconomicloss);
//                double d_vFPocketExpense = Convert.ToDouble(vFPocketExpense);
//                double d_vFCareCost = Convert.ToDouble(vFCareCost);

//                bool status = true;

//                if (d_vTotalDamages != Convert.ToDouble(ExcelVerify.ReadData(10, "Past_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Total Damages value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V1.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("TotalDamages", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v1.png").Build());
//                    status = false;
//                }
//                if (d_vPeconomicloss != Convert.ToDouble(ExcelVerify.ReadData(13, "Past_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Economic loss value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V2.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("Peconomicloss", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v2.png").Build());
//                    status = false;
//                }
//                if (d_vPPocketExpense != Convert.ToDouble(ExcelVerify.ReadData(14, "Past_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Pocket Expense value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V3.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("PocketExpense", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v3.png").Build());
//                    status = false;
//                }
//                if (d_vPCareCost != Convert.ToDouble(ExcelVerify.ReadData(15, "Past_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Care Cost value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V4.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("PCareCost", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v4.png").Build());
//                    status = false;
//                }

//                if (d_vFeconomicloss != Convert.ToDouble(ExcelVerify.ReadData(13, "Future_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Economic loss value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V5.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("Feconomicloss", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v5.png").Build());
//                    status = false;
//                }
//                if (d_vFPocketExpense != Convert.ToDouble(ExcelVerify.ReadData(14, "Future_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Pocket Expense value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V6.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("FPocketExpense", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v6.png").Build());
//                    status = false;
//                }
//                if (d_vFCareCost != Convert.ToDouble(ExcelVerify.ReadData(15, "Future_Losses")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Care Cost value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V7.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("CareCost", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v7.png").Build());
//                    status = false;
//                }

//                string exGratia = AppDriver.rpage.ExGratiaAmount.gettext();
//                string LRD = AppDriver.rpage.LrdRealised.gettext();
//                string TotalEstimate = AppDriver.rpage.TotalEstimate.gettext();
//                string netincurred = AppDriver.rpage.NetLiability.gettext();
//                string GrossIncurred = AppDriver.rpage.GrossIncurred.gettext();

//                double d_exGratia = Convert.ToDouble(exGratia);
//                double d_LRD = Convert.ToDouble(LRD);
//                double d_TotalEstimate = Convert.ToDouble(TotalEstimate);
//                double d_netincurred = Convert.ToDouble(netincurred);
//                double d_GrossIncurred = Convert.ToDouble(GrossIncurred);

//                if (d_exGratia != Convert.ToDouble(ExcelVerify.ReadData(6, "Legal_Cost")))
//                {
//                    AppDriver.test.Log(Status.Fail, "Exgratia value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V11.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("Exgratia", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v11.png").Build());
//                    status = false;
//                }
//                string tt2 = ExcelVerify.ReadData(21, "Legal_Cost");
//                double d_tt2 = Convert.ToDouble(tt2);
//                double f_tt2 = (d_tt2 * 100);
//                if (d_LRD != Math.Round(f_tt2, 2))
//                {
//                    AppDriver.test.Log(Status.Fail, "LRD value is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V12.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("LRD", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v12.png").Build());
//                    status = false;
//                }

//                double total_estimate_diff = Math.Round(Convert.ToDouble(ExcelVerify.ReadData(29, "Legal_Cost")) - d_TotalEstimate, 2);
//                if (Math.Abs(total_estimate_diff) > 0.01)
//                {
//                    AppDriver.test.Log(Status.Fail, "Total Estimate value(Excel:" + Convert.ToDouble(ExcelVerify.ReadData(29, "Legal_Cost")).ToString() + ";Actual:" + d_TotalEstimate.ToString() + ";Diff:" + Math.Abs(total_estimate_diff).ToString() + ") is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V14.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("TotalEstimate", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v14.png").Build());
//                    status = false;
//                }

//                double net_estimate_diff = Math.Round(Convert.ToDouble(ExcelVerify.ReadData(30, "Legal_Cost")) - d_netincurred, 2);
//                if (Math.Abs(net_estimate_diff) > 0.01)
//                {
//                    AppDriver.test.Log(Status.Fail, "Net Estimate value(Excel:" + Convert.ToDouble(ExcelVerify.ReadData(30, "Legal_Cost")).ToString() + ";Actual:" + d_netincurred.ToString() + ";Diff:" + Math.Abs(net_estimate_diff).ToString() + ") is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V15.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("Netincurred", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v15.png").Build());
//                    status = false;
//                }

//                double gross_incurred_diff = Math.Round(Convert.ToDouble(ExcelVerify.ReadData(31, "Legal_Cost")) - d_GrossIncurred, 2);
//                if (Math.Abs(gross_incurred_diff) > 0.01)
//                {
//                    AppDriver.test.Log(Status.Fail, "Gross Incurred value(Excel:" + Convert.ToDouble(ExcelVerify.ReadData(31, "Legal_Cost")).ToString() + ";Actual:" + d_GrossIncurred.ToString() + ";Diff:" + Math.Abs(gross_incurred_diff).ToString() + ") is not correct");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step V16.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("GrossIncurred", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step v16.png").Build());
//                    status = false;
//                }

//                if (status == true)
//                {
//                    AppDriver.test.Log(Status.Pass, "Step 9 : Indemnity reserve Values are  Correct as per data sheet");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step9.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Pass("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "step9.png").Build());
//                    AppDriver.driver.Close();
//                    AppDriver.driver.Dispose();
//                }
//                else
//                {
//                    AppDriver.test.Log(Status.Fail, "Step 9: All the values are not correct as per Data sheet. Check the report");
//                    AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                    AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step9.png", ScreenshotImageFormat.Png);
//                    AppDriver.test.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "Step9.png").Build());
//                    AppDriver.driver.Close();
//                    AppDriver.driver.Dispose();
//                }

//            }
//            catch (Exception e)
//            {
//                AppDriver.test.Log(Status.Fail, "Step End: Test Execution stopped due to error. " + e.Message);
//                AppDriver.file = ((ITakesScreenshot)AppDriver.driver).GetScreenshot();
//                AppDriver.file.SaveAsFile(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "StepEnd.png", ScreenshotImageFormat.Png);
//                AppDriver.test.Fail("Screenshot", MediaEntityBuilder.CreateScreenCaptureFromPath(ConfigurationManager.AppSettings["ReportsPath"] + ExcelUtil.ReadData(1, "Test_Folder_Name") + "StepEnd.png").Build());
//                AppDriver.driver.Quit();
//                AppDriver.driver.Dispose();

//            }
//        }
//    }
//}

