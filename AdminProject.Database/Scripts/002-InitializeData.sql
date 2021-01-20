USE [CRMDb]
GO
SET IDENTITY_INSERT [dbo].[BuilderMaster] ON 

INSERT [dbo].[BuilderMaster] ([Id], [Name], [Description], [EstablishmentYear], [CompletedProjectsCount], [Image], [Logo]) VALUES (1, N'ABC Contructions and Builders', N'ABC Deals in Real Estate construction business ', CAST(N'1990-10-10T00:00:00.0000000' AS DateTime2), 21, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BuilderMaster] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FirstName], [LastName], [UserName], [Password], [Image], [Email], [AccountStatus], [Phone], [Mobile], [AltMobile], [Facebook], [Linkedin], [Instagram], [ReferredByUserId], [ReferenceSource], [Remarks]) VALUES (1, 0, 20, CAST(N'2021-01-19' AS Date), NULL, NULL, N'Random', N'Cust1', N'rancust1', N'234566', NULL, N'34567gf@ytfuyf.com', 2, N'983948231', N'984924923', NULL, NULL, NULL, NULL, NULL, 0, N'Customer test for enquiry')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[CompanyMaster] ON 

INSERT [dbo].[CompanyMaster] ([Id], [Name], [Code], [DivisionId]) VALUES (1, N'Admin Company', N'100', 1)
SET IDENTITY_INSERT [dbo].[CompanyMaster] OFF
SET IDENTITY_INSERT [dbo].[UserMaster] ON 

INSERT [dbo].[UserMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FirstName], [LastName], [UserName], [Password], [Image], [EmpCode], [Email], [AccountStatus], [IsActive], [SeniorEmpId], [IsEmployee], [Phone], [Mobile], [CompanyId], [UserType]) VALUES (20, 0, 20, CAST(N'2021-01-02T21:27:40.9706117' AS DateTime2), 20, CAST(N'2021-01-02T22:59:59.3437736' AS DateTime2), N'Neeraj', N'S', N'IADxwnwnBu', N'$8(~`5(~^$baButnIAyqDxSO', NULL, NULL, N'wrGxlga}mlGxGxroNDwvGx^$IAa}DxwnwnBu', 1, 1, NULL, 1, N'678989981', N'9989786752', 1, NULL)
INSERT [dbo].[UserMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FirstName], [LastName], [UserName], [Password], [Image], [EmpCode], [Email], [AccountStatus], [IsActive], [SeniorEmpId], [IsEmployee], [Phone], [Mobile], [CompanyId], [UserType]) VALUES (21, 0, 0, CAST(N'2021-01-04T23:43:02.2908357' AS DateTime2), NULL, NULL, N'Neeraj', N'Singh', N'DxwnwnBua}tnokBuyqIA', N'$8(~`5(~^$baButnIAyqDxSO', NULL, NULL, N'wrGxlga}royqbawrQH^$DxwnwnBua}tnokBuyqIA', 1, 1, NULL, 1, N'678989981', N'9989786752', 1, NULL)
INSERT [dbo].[UserMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FirstName], [LastName], [UserName], [Password], [Image], [EmpCode], [Email], [AccountStatus], [IsActive], [SeniorEmpId], [IsEmployee], [Phone], [Mobile], [CompanyId], [UserType]) VALUES (22, 1, 20, CAST(N'2021-01-09T01:12:17.5826049' AS DateTime2), NULL, NULL, N'Test', N'User', N'IADxwnwnBu', N'`5(~`5(~^$', NULL, NULL, N'wrGxlga}mlGxGxroNDwvGx^$IAa}DxwnwnBu', 1, 1, NULL, 1, N'678989981', N'9989786752', 1, NULL)
INSERT [dbo].[UserMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FirstName], [LastName], [UserName], [Password], [Image], [EmpCode], [Email], [AccountStatus], [IsActive], [SeniorEmpId], [IsEmployee], [Phone], [Mobile], [CompanyId], [UserType]) VALUES (23, 1, 20, CAST(N'2021-01-09T01:13:31.9080918' AS DateTime2), NULL, NULL, N'Test', N'User', N'IADxwnwnBu', N'`5(~`5(~^$', NULL, NULL, N'wrGxlga}mlGxGxroNDwvGx^$IAa}DxwnwnBu', 1, 1, NULL, 1, N'678989981', N'9989786752', 1, NULL)
SET IDENTITY_INSERT [dbo].[UserMaster] OFF
SET IDENTITY_INSERT [dbo].[PropertyType] ON 

INSERT [dbo].[PropertyType] ([PropertyTypeId], [Name], [Description], [Direction]) VALUES (1, N'Residential High Rise', N'Residential Socities with high rise multiple towers', N'North')
INSERT [dbo].[PropertyType] ([PropertyTypeId], [Name], [Description], [Direction]) VALUES (2, N'Residential Low Rise', N'Residential society with 3 or less floors in each tower', N'West South')
INSERT [dbo].[PropertyType] ([PropertyTypeId], [Name], [Description], [Direction]) VALUES (3, N'Corporate Building', N'Business Offices', N'West')
INSERT [dbo].[PropertyType] ([PropertyTypeId], [Name], [Description], [Direction]) VALUES (4, N'Residential Villas', N'Propert has villas spread in large areas', N'All')
SET IDENTITY_INSERT [dbo].[PropertyType] OFF
SET IDENTITY_INSERT [dbo].[PropertyMaster] ON 

INSERT [dbo].[PropertyMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [PropertyName], [PropertyId], [AreaSize], [ConstructionStatus]) VALUES (2, 0, 20, CAST(N'2021-01-19' AS Date), NULL, NULL, N'Apex Golf Vista', 1, 5, 3)
INSERT [dbo].[PropertyMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [PropertyName], [PropertyId], [AreaSize], [ConstructionStatus]) VALUES (3, 0, 20, CAST(N'2021-01-19' AS Date), NULL, NULL, N'XYZ New Society', 1, 15, 2)
SET IDENTITY_INSERT [dbo].[PropertyMaster] OFF
SET IDENTITY_INSERT [dbo].[BuilderProperties] ON 

INSERT [dbo].[BuilderProperties] ([Id], [BuilderId], [PropertyId]) VALUES (1, 1, 2)
INSERT [dbo].[BuilderProperties] ([Id], [BuilderId], [PropertyId]) VALUES (2, 1, 3)
SET IDENTITY_INSERT [dbo].[BuilderProperties] OFF
SET IDENTITY_INSERT [dbo].[EmailTemplate] ON 

INSERT [dbo].[EmailTemplate] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Name], [Type], [Status], [HtmlContent], [Subject], [Cost], [AuthorName], [About], [TemplateCode]) VALUES (1, 0, 20, CAST(N'2021-01-03T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Forget Password', 2, 1, N'<html><head> <title>Password Reset Email| {{COMPANY}}</title> <meta http-equiv="Content-Type" content="text/html; charset=windows-1252"> <meta name="ProgId" content="Word.Document"> <meta name="Generator" content="Microsoft Word 14"> <meta name="Originator" content="Microsoft Word 14"> <style type="text/css" rel="stylesheet" media="all"> /* Base ------------------------------ */ *:not(br):not(tr):not(html) { font-family: Arial, ''Helvetica Neue'', Helvetica, sans-serif; } body { width: 100% !important; height: 100%; margin: 0; line-height: 1.4; background-color: #F2F4F6; color: #74787E; -webkit-text-size-adjust: none; } p, ul, ol, blockquote { line-height: 1.4; text-align: left; } a { color: #3869D4; } a img { border: none; } td { word-break: break-word; } /* Layout ------------------------------ */ .email-wrapper { width: 100%; margin: 0; padding: 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; background-color: #F2F4F6; } .email-content { width: 100%; margin: 0; padding: 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; } /* Masthead ----------------------- */ .email-masthead { padding: 25px 0; text-align: center; } .email-masthead_logo { width: 94px; } .email-masthead_name { font-size: 16px; font-weight: bold; color: #bbbfc3; text-decoration: none; text-shadow: 0 1px 0 white; } /* Body ------------------------------ */ .email-body { width: 100%; margin: 0; padding: 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; border-top: 1px solid #EDEFF2; border-bottom: 1px solid #EDEFF2; background-color: #FFFFFF; } .email-body_inner { width: 570px; margin: 0 auto; padding: 0; -premailer-width: 570px; -premailer-cellpadding: 0; -premailer-cellspacing: 0; background-color: #FFFFFF; } .email-footer { width: 570px; margin: 0 auto; padding: 0; -premailer-width: 570px; -premailer-cellpadding: 0; -premailer-cellspacing: 0; text-align: center; } .email-footer p { color: #AEAEAE; } .body-action { width: 100%; margin: 30px auto; padding: 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; text-align: center; } .body-sub { margin-top: 25px; padding-top: 25px; border-top: 1px solid #EDEFF2; } .content-cell { padding: 35px; } .preheader { display: none !important; visibility: hidden; mso-hide: all; font-size: 1px; line-height: 1px; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; } /* Attribute list ------------------------------ */ .attributes { margin: 0 0 21px; } .attributes_content { background-color: #EDEFF2; padding: 16px; } .attributes_item { padding: 0; } /* Related Items ------------------------------ */ .related { width: 100%; margin: 0; padding: 25px 0 0 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; } .related_item { padding: 10px 0; color: #74787E; font-size: 15px; line-height: 18px; } .related_item-title { display: block; margin: .5em 0 0; } .related_item-thumb { display: block; padding-bottom: 10px; } .related_heading { border-top: 1px solid #EDEFF2; text-align: center; padding: 25px 0 10px; } /* Discount Code ------------------------------ */ .discount { width: 100%; margin: 0; padding: 24px; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; background-color: #EDEFF2; border: 2px dashed #9BA2AB; } .discount_heading { text-align: center; } .discount_body { text-align: center; font-size: 15px; } /* Social Icons ------------------------------ */ .social { width: auto; } .social td { padding: 0; width: auto; } .social_icon { height: 20px; margin: 0 8px 10px 8px; padding: 0; } /* Data table ------------------------------ */ .purchase { width: 100%; margin: 0; padding: 35px 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; } .purchase_content { width: 100%; margin: 0; padding: 25px 0 0 0; -premailer-width: 100%; -premailer-cellpadding: 0; -premailer-cellspacing: 0; } .purchase_item { padding: 10px 0; color: #74787E; font-size: 15px; line-height: 18px; } .purchase_heading { padding-bottom: 8px; border-bottom: 1px solid #EDEFF2; } .purchase_heading p { margin: 0; color: #9BA2AB; font-size: 12px; } .purchase_footer { padding-top: 15px; border-top: 1px solid #EDEFF2; } .purchase_total { margin: 0; text-align: right; font-weight: bold; color: #2F3133; } .purchase_total--label { padding: 0 15px 0 0; } /* Utilities ------------------------------ */ .align-right { text-align: right; } .align-left { text-align: left; } .align-center { text-align: center; } /*Media Queries ------------------------------ */ @media only screen and (max-width: 600px) { .email-body_inner, .email-footer { width: 100% !important; } } @media only screen and (max-width: 500px) { .button { width: 100% !important; } } /* Buttons ------------------------------ */ .button { background-color: #3869D4; border-top: 10px solid #3869D4; border-right: 18px solid #3869D4; border-bottom: 10px solid #3869D4; border-left: 18px solid #3869D4; display: inline-block; color: #FFF; text-decoration: none; border-radius: 3px; box-shadow: 0 2px 3px rgba(0, 0, 0, 0.16); -webkit-text-size-adjust: none; } .button--green { background-color: #22BC66; border-top: 10px solid #22BC66; border-right: 18px solid #22BC66; border-bottom: 10px solid #22BC66; border-left: 18px solid #22BC66; } .button--pink{ background-color: #ff7f7a; border-top: 10px solid #ff7f7a; border-right: 18px solid #ff7f7a; border-bottom: 10px solid #ff7f7a; border-left: 18px solid #ff7f7a; } /* Type ------------------------------ */ h1 { margin-top: 0; color: #2F3133; font-size: 19px; font-weight: bold; text-align: left; } h2 { margin-top: 0; color: #2F3133; font-size: 16px; font-weight: bold; text-align: left; } h3 { margin-top: 0; color: #2F3133; font-size: 14px; font-weight: bold; text-align: left; } p { margin-top: 0; color: #74787E; font-size: 16px; line-height: 1.5em; text-align: left; } p.sub { font-size: 12px; } p.center { text-align: center; } </style> </head> <body> <div class="_rp_N4 ms-font-weight-regular ms-font-color-neutralDark rpHighlightAllClass rpHighlightBodyClass" id="Item.MessageUniqueBody" tabindex="0" style="font-family: wf_segoe-ui_normal, Segoe UI, Segoe WP, Tahoma, Arial, sans-serif, serif, EmojiFont;"> <div class="rps_b4f9"> <div> <div leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" style="font-size: 10pt; font-family: MS Sans Serif, serif, EmojiFont;"> <table cellspacing="0" cellpadding="0" width="600" align="center" bgcolor="#ffffff" border="0"> <tbody> <tr> <td valign="middle" align="center" style="font-size:1px; font-family:Arial,Helvetica,sans-serif; color:#ffffff"> The delight of simple. </td> </tr> <tr> <td valign="top" align="left"> <table cellspacing="0" cellpadding="0" width="600" align="center" border="0" style="font- size:0px"> <tbody> <tr> <td bgcolor="#9a9a9a" valign="top" width="1" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="1" style="display:block"></td> <td valign="top" width="598" align="left"> <table cellspacing="0" cellpadding="0" width="598" border="0"> <tbody> <tr> <td bgcolor="#9a9a9a" valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="1" style="display:block"></td> </tr> <tr> <td valign="top" align="center"> <table cellspacing="0" cellpadding="0" width="598" border="0"> <tbody> <tr> <td> <table border="0" align="left" width="598" cellpadding="0" cellspacing="0"> <tbody> <tr height="80px"> <td bgcolor="#ecf0f1"> <div class="navbar-header"> <a class="navbar-brand" href="[COMPANYWEBURL]"><img style="width:auto;height:60px;" src="[COMPANYLOGOURL]" alt="logo"></a> </div> </td> </tr> <tr> <td bgcolor="#ffffff" valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="5" style="display:block"></td> </tr> </tbody> </table> </td> </tr> <tr> <td valign="top" align="left"> <table cellspacing="0" cellpadding="0" width="598" align="center" border="0"> <tbody> <tr> </tr> </tbody> </table> </td> </tr> <tr> <td valign="top" align="center"> <div style=" text-align: left; padding-left: 10px; padding-top: 20px;"> <font color="#000000" size="2" face="Microsoft Sans Serif" style="font-family: Microsoft Sans Serif, serif, EmojiFont;"> <div> <p>Dear {{FNAME}},</p> </div> <br> <div></div> <div> <p> You have requested a password reset, please follow the link below to reset your password. </p> <p> Please ignore this email if you did not request a password change. </p> <p style=" text-align: center; "> <a href="{{UNIQUESTR}}" class="button button--pink" target="_blank">Click To Reset Password</a> </p> </div> <div><br></div> <p>Our Customer Service team is always ready to assist you in case you are having trouble with your password. </p> <p> Customer Service Team <br> {{COMPANY}} </p> </font> </div><table border="0" align="center" width="565" cellpadding="0" cellspacing="0"> <tbody> <tr> <td valign="top" colspan="2" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="8" style="display:block"></td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="6" style="display:block"></td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="12" style="display:block"></td> </tr> <tr> <td valign="top" align="left" style="font-size:11px; font-family:Arial,Helvetica,sans-serif; color:#aeaeae"> <strong>CONNECT WITH {{COMPANY}}</strong> </td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="6" style="display:block"></td> </tr> <tr> <td bgcolor="#adaeae" valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="1" style="display:block"></td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="10" style="display:block"></td> </tr> <tr> <td valign="top" align="center"> <table cellspacing="0" cellpadding="0" width="273" border="0"> <tbody> <tr> <td valign="top"><a href="https://www.facebook.com/accuit" target="_blank" rel="noopener noreferrer" style="color:#1365c2"><img src="http://oica.org/wp- content/uploads/2016/01/social-facebook-box-blue-icon-430x512.png" title="Facebook" border="0" alt="Facebook" width="65" height="70" style="display:block;/* padding-left: 60px; */"></a></td> <td valign="top"><a href="https://plus.google.com/+Accuitechservesbetter/posts" target="_blank" rel="noopener noreferrer" style="color:#1365c2"><img src="http://accuitech.com/Content/images/googleplus.png" title="Facebook" border="0" alt="Facebook" width="67" height="67" style="display:block;padding-left: 40px;"></a></td> <td valign="top" width="128" align="left"><a href="https://twitter.com/accuitech" target="_blank" rel="noopener noreferrer" style="color:#1365c2"><img src="https://1.bp.blogspot.com/-kbviOAaq2ds/T-n4PulsfwI/AAAAAAAADpo/YvXmzmRloLw/s1600/twitter-twitter-icon.png" title="Facebook" border="0" alt="Facebook" width="65" height="60" style="display:block;padding-top: 5px;padding-left: 40px;"></a></td> <td valign="top" width="145" align="left"><a href="https://www.linkedin.com/company/accuit-technologies" target="_blank" rel="noopener noreferrer" style="color:#1365c2"><img src="https://bewelldogood.files.wordpress.com/2012/04/linkedin-logo-icon.png" title="Accuitech.com" border="0" alt="accuitech.com" width="65" height="60" style="display:block;padding-top: 5px;padding-left: 40px;"></a></td> </tr> </tbody> </table> </td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="10" style="display:block"></td> </tr> <tr> <td bgcolor="#adaeae" valign="top" align="left"> <img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="1" style="display:block"> </td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="6" style="display:block"></td> </tr> <tr> <td valign="top" align="left" style="font-size:10px; font-family:Arial,Helvetica,sans-serif; color:#939598"> This communication is to inform you about receiving your message successfully. This may be our first contact but this may lead us to achieve successful business bond. </td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="6" style="display:block"></td> </tr> <tr> <td valign="top" align="left" style="font-size:10px; font-family:Arial,Helvetica,sans-serif; color:#939598"> <div align="justify" style="font- family: Arial, Helvetica, sans-serif, serif, EmojiFont;"> This emailer is intended only for Accuit customers and does not tantamount to spamming. You are advised to contact AccuIT Technologies to clarify any questions you may have with regard to any information contained in this emailer. Accuit N.A. and/or any of their affiliates/associates have no liability whatsoever to any person on account of the use of information provided herein and the said information is provided on a best-effort basis. </div> </td> </tr> <tr> <td height="6" valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="6" style="display:block"></td> </tr> <tr> <td valign="top" align="left" style="font-size:10px; font-family:Arial,Helvetica,sans-serif; color:#939598"> <div align="justify" style="font- family: Arial, Helvetica, sans-serif, serif, EmojiFont;">Please do not reply to this mail as it is a computer generated mail. For further information, please follow the instructions mentioned above.</div> </td> </tr> <tr> <td valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="8" style="display:block"></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </td> </tr> <tr> <td bgcolor="#9a9a9a" valign="top" align="left"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="1" style="display:block"></td> </tr> </tbody> </table> </td> <td bgcolor="#9a9a9a" valign="top" width="1" align="right"><img src="http://accuitech.com/Content/images/Emailer/spacer.gif" width="1" height="1" style="display:block"></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> </div> </div> </div> </body></html>
', N'Reset your {{COMPANY}} account password', NULL, NULL, N'Forget Password', 102)
INSERT [dbo].[EmailTemplate] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Name], [Type], [Status], [HtmlContent], [Subject], [Cost], [AuthorName], [About], [TemplateCode]) VALUES (3, 0, 20, CAST(N'2021-01-03T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Confirm Registration', 1, 1, N'<!DOCTYPE html>
<html>


<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <style type="text/css">
        @media screen {
            @font-face {
                font-family: ''Lato'';
                font-style: normal;
                font-weight: 400;
                src: local(''Lato Regular''), local(''Lato-Regular''), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format(''woff'');
            }

            @font-face {
                font-family: ''Lato'';
                font-style: normal;
                font-weight: 700;
                src: local(''Lato Bold''), local(''Lato-Bold''), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format(''woff'');
            }

            @font-face {
                font-family: ''Lato'';
                font-style: italic;
                font-weight: 400;
                src: local(''Lato Italic''), local(''Lato-Italic''), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format(''woff'');
            }

            @font-face {
                font-family: ''Lato'';
                font-style: italic;
                font-weight: 700;
                src: local(''Lato Bold Italic''), local(''Lato-BoldItalic''), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format(''woff'');
            }
        }

        /* CLIENT-SPECIFIC STYLES */
        body,
        table,
        td,
        a {
            -webkit-text-size-adjust: 100%;
            -ms-text-size-adjust: 100%;
        }

        table,
        td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        img {
            -ms-interpolation-mode: bicubic;
        }

        /* RESET STYLES */
        img {
            border: 0;
            height: auto;
            line-height: 100%;
            outline: none;
            text-decoration: none;
        }

        table {
            border-collapse: collapse !important;
        }

        body {
            height: 100% !important;
            margin: 0 !important;
            padding: 0 !important;
            width: 100% !important;
        }

        /* iOS BLUE LINKS */
        a[x-apple-data-detectors] {
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }

        /* MOBILE STYLES */
        @media screen and (max-width:600px) {
            h1 {
                font-size: 32px !important;
                line-height: 32px !important;
            }
        }

        /* ANDROID CENTER FIX */
        div[style*="margin: 16px 0;"] {
            margin: 0 !important;
        }
    </style>
</head>

<body style="background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;">
    <!-- HIDDEN PREHEADER TEXT -->
    <div style="display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: ''Lato'', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;"> We''re thrilled to have you here! Get ready to dive into your new account. </div>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <!-- LOGO -->
        <tr>
            <td bgcolor="#FFA73B" align="center">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 600px;">
                    <tr>
                        <td align="center" valign="top" style="padding: 40px 10px 40px 10px;"> </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#FFA73B" align="center" style="padding: 0px 10px 0px 10px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 600px;">
                    <tr>
                        <td bgcolor="#ffffff" align="center" valign="top" style="padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;">
                            <h1 style="font-size: 48px; font-weight: 400; margin: 2;">Welcome!</h1> <img src=" https://img.icons8.com/clouds/100/000000/handshake.png" width="125" height="120" style="display: block; border: 0px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#f4f4f4" align="center" style="padding: 0px 10px 0px 10px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 600px;">
                    <tr>
                        <td bgcolor="#ffffff" align="left" style="padding: 20px 30px 40px 30px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;">
                            <p style="margin: 0;"> Dear {{FNAME}} {{LNAME}},</p>
                            <p style="margin: 0;"> We''re excited to have you get started. First, you need to confirm your account. Just click on the button below.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#ffffff" align="left">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td bgcolor="#ffffff" align="center" style="padding: 20px 30px 60px 30px;">
                                        <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="center" style="border-radius: 3px;" bgcolor="#FFA73B">
                                                <a href="{{URL}}" target="_blank" style="font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #FFA73B; display: inline-block;">Confirm Account</a></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr> <!-- COPY -->
                    <tr>
                        <td bgcolor="#ffffff" align="left" style="padding: 0px 30px 0px 30px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;">
                            <p style="margin: 0;">If that doesn''t work, copy and paste the following link in your browser:</p>
                        </td>
                    </tr> <!-- COPY -->
                    <tr>
                        <td bgcolor="#ffffff" align="left" style="padding: 20px 30px 20px 30px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;">
                            <p style="margin: 0;"><a href="#" target="_blank" style="color: #FFA73B;">{{URL}}</a></p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#ffffff" align="left" style="padding: 0px 30px 20px 30px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;">
                            <p style="margin: 0;">If you have any questions, just reply to this email—we''re always happy to help out.</p>
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="#ffffff" align="left" style="padding: 0px 30px 40px 30px; border-radius: 0px 0px 4px 4px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;">
                            <p style="margin: 0;">Cheers,<br>{{COMPANY}}</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#f4f4f4" align="center" style="padding: 30px 10px 0px 10px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 600px;">
                    <tr>
                        <td bgcolor="#FFECD1" align="center" style="padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;">
                            <h2 style="font-size: 20px; font-weight: 400; color: #111111; margin: 0;">Need more help?</h2>
                            <p style="margin: 0;"><a href="#" target="_blank" style="color: #FFA73B;">We&rsquo;re here to help you out</a></p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td bgcolor="#f4f4f4" align="center" style="padding: 0px 10px 0px 10px;">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="max-width: 600px;">
                    <tr>
                        <td bgcolor="#f4f4f4" align="left" style="padding: 0px 30px 30px 30px; color: #666666; font-family: ''Lato'', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;"> <br>
                            <p style="margin: 0;">If these emails get annoying, please feel free to <a href="#" target="_blank" style="color: #111111; font-weight: 700;">unsubscribe</a>.</p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>

</html>', N'Thank you for being a part of {{COMPANY}} family. Please verify your registered email.', NULL, NULL, NULL, 101)
SET IDENTITY_INSERT [dbo].[EmailTemplate] OFF
SET IDENTITY_INSERT [dbo].[EmailMergeFields] ON 

INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (1, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'First Name', N'FNAME', NULL, NULL, NULL, 1)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (2, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Last Name', N'LNAME', NULL, NULL, NULL, 1)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (3, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Unique String', N'UNIQUESTR', NULL, NULL, NULL, 1)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (4, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Company Name', N'COMPANY', N'Dream Wedds', NULL, NULL, 1)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (5, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'First Name', N'FNAME', NULL, NULL, NULL, 3)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (6, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Last Name', N'LNAME', NULL, NULL, NULL, 3)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (7, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Url', N'URL', NULL, NULL, NULL, 3)
INSERT [dbo].[EmailMergeFields] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [FieldName], [SrcField], [SrcFieldValue], [Sequence], [TemplateCode], [EmailTemplateId]) VALUES (8, 1, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Company Name', N'COMPANY', N'Dream Wedds', NULL, NULL, 3)
SET IDENTITY_INSERT [dbo].[EmailMergeFields] OFF
SET IDENTITY_INSERT [dbo].[RoleMaster] ON 

INSERT [dbo].[RoleMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Name], [Code], [Type], [Status], [IsAdmin], [RoleDescription]) VALUES (3, 0, 2, CAST(N'2021-01-02T21:26:35.0321107' AS DateTime2), NULL, NULL, N'Admin', N'100', 1, 1, 1, N'Admin Role added by Admin')
INSERT [dbo].[RoleMaster] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [Name], [Code], [Type], [Status], [IsAdmin], [RoleDescription]) VALUES (4, 0, 2, CAST(N'2021-01-02T21:35:18.6377247' AS DateTime2), 20, CAST(N'2021-01-02T22:47:47.2063563' AS DateTime2), N'Employee', N'102', 2, 1, 1, N'Employee Role added by Admin')
SET IDENTITY_INSERT [dbo].[RoleMaster] OFF
SET IDENTITY_INSERT [dbo].[UserRoles] ON 

INSERT [dbo].[UserRoles] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RoleId], [UserId], [IsActive]) VALUES (2, 0, 0, CAST(N'2021-01-02T21:27:41.0179626' AS DateTime2), NULL, NULL, 3, 20, 1)
INSERT [dbo].[UserRoles] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RoleId], [UserId], [IsActive]) VALUES (3, 0, 0, CAST(N'2021-01-04T23:43:11.8548744' AS DateTime2), NULL, NULL, 3, 21, 1)
INSERT [dbo].[UserRoles] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RoleId], [UserId], [IsActive]) VALUES (4, 0, 20, CAST(N'2021-01-09T01:12:17.7004687' AS DateTime2), NULL, NULL, 3, 22, 1)
INSERT [dbo].[UserRoles] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [RoleId], [UserId], [IsActive]) VALUES (5, 0, 20, CAST(N'2021-01-09T01:13:31.9166653' AS DateTime2), NULL, NULL, 3, 23, 1)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF
SET IDENTITY_INSERT [dbo].[OtpMaster] ON 

INSERT [dbo].[OtpMaster] ([Id], [UserId], [Otp], [Guid], [CreatedDate], [Attempts]) VALUES (1, 20, N'664864', N'b6bc5fcc-e90f-4bd5-9a4f-159a8d496dab', CAST(N'2021-01-05T00:16:25.9031585' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[OtpMaster] OFF
SET IDENTITY_INSERT [dbo].[TASK] ON 

INSERT [dbo].[TASK] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TASKNAME], [TASKNAME_TID], [DESCRIPTION], [DESCRIPTION_TID]) VALUES (1, 0, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Change my Password', NULL, N'Change your own password for logging into WorkBenches.', NULL)
INSERT [dbo].[TASK] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TASKNAME], [TASKNAME_TID], [DESCRIPTION], [DESCRIPTION_TID]) VALUES (2, 0, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Maintain Access Account', NULL, N'Create, update or delete access accounts.', NULL)
INSERT [dbo].[TASK] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TASKNAME], [TASKNAME_TID], [DESCRIPTION], [DESCRIPTION_TID]) VALUES (3, 0, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Maintain User', NULL, N'Create, update or delete WorkBench users.', NULL)
INSERT [dbo].[TASK] ([Id], [IsDeleted], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate], [TASKNAME], [TASKNAME_TID], [DESCRIPTION], [DESCRIPTION_TID]) VALUES (4, 0, 20, CAST(N'2020-10-10T00:00:00.0000000' AS DateTime2), NULL, NULL, N'Maintain Role', NULL, N'Create, update or delete User Roles.', NULL)
SET IDENTITY_INSERT [dbo].[TASK] OFF
