<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs"
Inherits="BookFair.ResetPassword" Async="true"%>
<asp:content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    * {
      font-family: "Concert One", "ConcertOne";

      font-size: 16px;
    }

    .panel {
      display: flex;
      flex-direction: row;
      align-items: center;
      align-self: center;
      justify-self: center;
      height: 100%;
    }

    .panel-form-send-email {
      height: 100%;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      gap: 10px;
    }

    .welcome-image {
      width: 150px;
    }

    .error-msg {
      color: red;
    }

    .img-container {
      width: 100%;
    }

    .input-send-email {
      width: 100%;
      border-radius: 10px;
      height: 30px;
    }

    .btn_send_email {
      float: right;
      border-radius: 10px;
      margin: auto;
      background-color: #a27cff;
    }

    .heading-title-text {
      font-size: 30px;
      color: #ffc100;
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
      UseSubmitBehavior="false"
      ID="ASPxButtonBack"
      CssClass="btn-option-page-redirect"
      runat="server"
      OnClick="Goback_ButtonClick"
      Image-Url="~/utlis/Images/iconBack.svg"
      Image-Width="50px"
      CausesValidation="False"
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
  <dx:aspxpanel ID="ASPxPanel1" CssClass="panel" runat="server" Width="100%">
    <panelcollection>
      <dx:panelcontent>
        <div class="img-container">
          <dx:aspximage
            Width="100%"
            CssClass="img-login"
            ID="ASPxImage1"
            runat="server"
            ImageUrl="~/utlis/Images/NewEmailImg1.svg"
            ShowLoadingImage="true"
          >
          </dx:aspximage>
        </div>

        <dx:aspxpanel
          ID="ASPxPanel2"
          runat="server"
          CssClass="panel-form-send-email"
          width="100%"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspximage
                CssClass="welcome-image"
                ID="ASPxFormLayout1_E1"
                runat="server"
                ImageUrl="~/utlis/Images/iconbook1.svg"
              >
              </dx:aspximage>

              <dx:aspxlabel
                ID="ASPxFormLayout1_E10"
                runat="server"
                Text="Rest Your Password"
                CssClass="heading-title-text"
              >
              </dx:aspxlabel>

              <dx:aspxformlayout
                ID="ASPxFormLayoutSendEmail"
                runat="server"
                Width="100%"
                ShowItemCaptionColon="False"
                CssClass="Form-container-send-email-input"
              >
                <items>
                  <dx:layoutgroup
                    Caption
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
                      <dx:layoutitem Caption="Email" ColSpan="1" Name="email">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxtextbox
                              ID="ASPxInputEmail"
                              runat="server"
                              Placeholder="user@mail.com"
                              CssClass="input-send-email email-text-input-send"
                              NullText="ex@mail.com"
                              Width="100%"
                            >
                              <validationsettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                                EnableCustomValidation="True"
                              >
                                <regularexpression
                                  ErrorText="Wrong Email Format"
                                  ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$"
                                />
                                <requiredfield
                                  IsRequired="True"
                                  ErrorText="Email is required"
                                />
                              </validationsettings>
                            </dx:aspxtextbox>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                        <captionsettings VerticalAlign="Middle" />
                      </dx:layoutitem>

                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxbutton
                              ID="ASPxButtonSendEmail"
                              runat="server"
                              CssClass="btn_send_email"
                              Text="Reset Password"
                              Height="40px"
                              HorizontalAlign="Center"
                              VerticalAlign="Middle"
                              Width="150px"
                              OnClick="ASPxButtonSendEmail_Click"
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
                              Text="The Email is Not Registered Or An Error Occurred"
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
</asp:content>
