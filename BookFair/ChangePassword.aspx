<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs"
Inherits="BookFair.ChangePassword" Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    * {
      font-family: "Concert One", "ConcertOne";

      font-size: 16px;
    }

    .panel {
      display: flex;
      flex-direction: row;
      align-items: center;
    }

    .error-msg {
      color: red;
    }

    .panel-form-change-password {
      height: 100%;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      gap: 10px;
    }

    .register-container {
      display: flex;
      flex-direction: row;
      align-items: center;
      gap: 5px;
    }
    .header-img {
      width: 150px;
    }

    .Form-Container-change-password {
      padding: 0;
    }

    .img-change-password {
      width: 100%;
    }

    .heading-change-password-text {
      font-size: 30px;
      color: #fda85a;
    }

    .img-container {
      width: 100%;
    }

    .input-change-password {
      width: 100%;
      border-radius: 10px;
      height: 30px;
    }

    .btn-change-password {
      float: right;
      border-radius: 10px;
      margin: auto;
      background-color: #fda85a;
    }
    .page-redirect-container {
      width: 260px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin-bottom: 30px;
      padding: 20px;
    }
    .btn-option-page-redirect {
      background-color: transparent;
    }

    .label-page-redirect {
      font-size: 15px;
    }
  </style>

  <div class="page-redirect-container">
    <dx:ASPxButton
      ID="ASPxButtonBack"
      UseSubmitBehavior="false"
      CssClass="btn-option-page-redirect"
      runat="server"
      OnClick="Goback_ButtonClick"
      CausesValidation="False"
      Image-Url="~/utlis/Images/iconBack.svg"
      Image-Width="50px"
    >
      <Image Width="50px" Url="~/utlis/Images/iconBack.svg"></Image>
    </dx:ASPxButton>
    <dx:aspxlabel
      ID="labelPageRedirect"
      CssClass="label-page-redirect"
      Text="Go Back To Login Page"
      runat="server"
    ></dx:aspxlabel>
  </div>
  <dx:aspxpanel ID="ASPxPanel1" runat="server" CssClass="panel" width="100%">
    <panelcollection>
      <dx:panelcontent>
        <div class="img-container">
          <dx:aspximage
            Width="100%"
            CssClass="img-change-password"
            ID="ASPxImage1"
            runat="server"
            ImageUrl="~/utlis/Images/Reset password-cuate.svg"
            ShowLoadingImage="true"
          >
          </dx:aspximage>
        </div>

        <dx:aspxpanel
          ID="ASPxPanel2"
          runat="server"
          CssClass="panel-form-change-password"
          width="100%"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspximage
                CssClass="header-img"
                ID="ASPxFormLayout1_E1"
                runat="server"
                ImageUrl="~/utlis/Images/iconbook2.svg"
              >
              </dx:aspximage>

              <dx:aspxlabel
                ID="ASPxFormLayout1_E10"
                runat="server"
                Text="Reset Password To A New One"
                CssClass="heading-change-password-text"
              >
              </dx:aspxlabel>

              <dx:aspxformlayout
                ID="ASPxFormLayout1"
                runat="server"
                Width="100%"
                ShowItemCaptionColon="False"
                CssClass="Form-container-change-password-input"
              >
                <items>
                  <dx:layoutgroup
                    Caption=""
                    ColSpan="1"
                    CssClass="group-component-input-container"
                    ShowCaption="False"
                  >
                    <bordertop BorderStyle="None" />
                    <border BorderStyle="None" />
                    <paddings PaddingLeft="150px" PaddingRight="150px" />
                    <groupboxstyle>
                      <border BorderStyle="None" />
                    </groupboxstyle>
                    <items>
                      <dx:layoutitem
                        Caption="New Password"
                        ColSpan="1"
                        Name="newPassword"
                      >
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:ASPxTextBox
                              ID="TB_New_Password"
                              runat="server"
                              Password="True"
                              CssClass="input-change-password password-text-input-register"
                              TextMode="Password"
                              Placeholder="Enter your password"
                              Width="100%"
                              NullText="Enter A New Password"
                            >
                              <ValidationSettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                              >
                                <ErrorFrameStyle Wrap="True"> </ErrorFrameStyle>
                                <RegularExpression
                                  ErrorText="New Password must be at least 8 characters, contain at least one one lower case letter, one upper case letter,  one digit and one special character"
                                  ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$"
                                />
                                <RequiredField
                                  IsRequired="True"
                                  ErrorText="Password is required"
                                />
                              </ValidationSettings>
                            </dx:ASPxTextBox>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                        <captionsettings VerticalAlign="Middle" />
                      </dx:layoutitem>
                      <dx:layoutitem
                        Caption="Confirm Password"
                        ColSpan="1"
                        Name="confirmPassword"
                      >
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxtextbox
                              ID="TB_Confairm_pass"
                              runat="server"
                              Password="True"
                              CssClass="input-change-password password-text-input-change-password"
                              TextMode="Password"
                              Placeholder="Enter your Confirm password"
                              Width="100%"
                              NullText="Enter A Confirm Password"
                            >
                              <validationsettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                                EnableCustomValidation="True"
                              >
                                <errorframestyle Wrap="True"> </errorframestyle>
                                <requiredfield
                                  IsRequired="True"
                                  ErrorText="Confirm Password is required"
                                />
                              </validationsettings>
                            </dx:aspxtextbox>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxbutton
                              ID="FL_B_Log"
                              runat="server"
                              CssClass="btn-change-password"
                              Text="Change Password"
                              Height="40px"
                              HorizontalAlign="Center"
                              VerticalAlign="Middle"
                              Width="150px"
                              OnClick="FL_B_Log_Click"
                            >
                            </dx:aspxbutton>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxvalidationsummary
                              ID="ASPxValidationSummary1"
                              runat="server"
                            >
                            </dx:aspxvalidationsummary>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxlabel
                              Text="The Two Passwords Are Not The Same"
                              runat="server"
                              ID="ASPxLabelError"
                              CssClass="error-msg"
                              Visible="False"
                            ></dx:aspxlabel>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                    </items>
                  </dx:layoutgroup>
                </items>
              </dx:aspxformlayout>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>
      </dx:panelcontent>
    </panelcollection>
  </dx:aspxpanel>
</asp:Content>
