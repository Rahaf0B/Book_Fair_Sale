<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="CheckOTPCode.aspx.cs"
Inherits="BookFair.CheckOTPCode" Async="true"%>
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

    .input-check-code {
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

    .heading-login-text {
      font-size: 15px;
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
      CausesValidation="False"
      CssClass="btn-option-page-redirect"
      runat="server"
      OnClick="Goback_ButtonClick"
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
  <dx:ASPxPanel ID="ASPxPanel1" CssClass="panel" runat="server" Width="100%">
    <PanelCollection>
      <dx:PanelContent>
        <div class="img-container">
          <dx:ASPxImage
            Width="100%"
            CssClass="img-login"
            ID="ASPxImage1"
            runat="server"
            ImageUrl="~/utlis/Images/FrameOptcode.svg"
            ShowLoadingImage="true"
          >
          </dx:ASPxImage>
        </div>

        <dx:ASPxPanel
          ID="ASPxPanel2"
          runat="server"
          CssClass="panel-form-send-email"
          width="100%"
        >
          <PanelCollection>
            <dx:PanelContent>
              <dx:ASPxImage
                CssClass="welcome-image"
                ID="ASPxFormLayout1_E1"
                runat="server"
                ImageUrl="~/utlis/Images/bookiconcode.svg"
              >
              </dx:ASPxImage>

              <dx:ASPxLabel
                ID="ASPxFormLayout1_E10"
                runat="server"
                Text="Check Your Code"
                CssClass="heading-login-text"
              >
              </dx:ASPxLabel>

              <dx:ASPxFormLayout
                ID="ASPxFormLayoutCheckCode"
                runat="server"
                Width="100%"
                ShowItemCaptionColon="False"
                CssClass="Form-container-send-email-input"
              >
                <Items>
                  <dx:LayoutGroup
                    Caption=""
                    ColSpan="1"
                    CssClass="group-component-input-container"
                    ShowCaption="False"
                  >
                    <BorderTop BorderStyle="None" />
                    <Border BorderStyle="None" />
                    <Paddings PaddingLeft="150px" PaddingRight="150px" />
                    <GroupBoxStyle>
                      <Border BorderStyle="None" />
                    </GroupBoxStyle>
                    <Items>
                      <dx:LayoutItem
                        Caption="OTP Code"
                        ColSpan="1"
                        Name="otp-code"
                      >
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox
                              ID="ASPxInputCode"
                              runat="server"
                              Placeholder="user@mail.com"
                              CssClass="input-check-code code-text-input"
                              Width="100%"
                            >
                              <ValidationSettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                                EnableCustomValidation="True"
                              >
                                <RegularExpression ErrorText="" />
                                <RequiredField
                                  IsRequired="True"
                                  ErrorText="OTP Code is required"
                                />
                              </ValidationSettings>
                            </dx:ASPxTextBox>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <CaptionSettings VerticalAlign="Middle" />
                      </dx:LayoutItem>

                      <dx:LayoutItem Caption="" ColSpan="1" ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton
                              ID="ASPxButtonCheckCode"
                              runat="server"
                              CssClass="btn_send_email"
                              Text="Change Password"
                              Height="40px"
                              HorizontalAlign="Center"
                              VerticalAlign="Middle"
                              Width="150px"
                              OnClick="ASPxButtonCheckCode_Click"
                            >
                            </dx:ASPxButton>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                      </dx:LayoutItem>
                      <dx:LayoutItem Caption="" ColSpan="1" ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxValidationSummary
                              ID="ASPxValidationSummary1"
                              runat="server"
                            >
                            </dx:ASPxValidationSummary>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                      </dx:LayoutItem>

                      <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
                        <layoutitemnestedcontrolcollection>
                          <dx:layoutitemnestedcontrolcontainer runat="server">
                            <dx:aspxlabel
                              Text="The OTP Code Is Not Correct"
                              runat="server"
                              ID="ASPxLabelError"
                              CssClass="error-msg"
                              Visible="False"
                            ></dx:aspxlabel>
                          </dx:layoutitemnestedcontrolcontainer>
                        </layoutitemnestedcontrolcollection>
                      </dx:layoutitem>
                    </Items>
                  </dx:LayoutGroup>
                </Items>
              </dx:ASPxFormLayout>
            </dx:PanelContent>
          </PanelCollection>
        </dx:ASPxPanel>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>
</asp:Content>
