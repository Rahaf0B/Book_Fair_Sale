<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="Register.aspx.cs"
Inherits="BookFair.Register" Async="true" %>
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

    .panel-form-register {
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
    .welcome-image {
      width: 150px;
    }

    .Form-Container-register {
      padding: 0;
    }

    .img-register {
      width: 100%;
    }

    .img-container {
      width: 100%;
    }

    .input-register {
      width: 100%;
      border-radius: 10px;
      height: 30px;
    }

    .btn-register {
      float: right;
      border-radius: 10px;
      margin: auto;
      background-color: #f96756;
    }

    .hyp-register {
      color: #f87c1d;
      width: fit-content;
      text-decoration: none;
      cursor: pointer;
      color: #f96756;
      font-size: 20px;
    }

    .heading-register-text {
      font-size: 30px;
      color: #ff81ae;
    }
  </style>

  <dx:ASPxPanel ID="ASPxPanel1" runat="server" CssClass="panel" width="100%">
    <PanelCollection>
      <dx:PanelContent>
        <div class="img-container">
          <dx:ASPxImage
            Width="100%"
            CssClass="img-register"
            ID="ASPxImage1"
            runat="server"
            ImageUrl="~/utlis/Images/reg-back.svg"
            ShowLoadingImage="true"
          >
          </dx:ASPxImage>
        </div>

        <dx:ASPxPanel
          ID="ASPxPanel2"
          runat="server"
          CssClass="panel-form-register"
          width="100%"
        >
          <PanelCollection>
            <dx:PanelContent>
              <dx:ASPxImage
                CssClass="welcome-image"
                ID="ASPxFormLayout1_E1"
                runat="server"
                ImageUrl="~/utlis/Images/reg-icon.svg"
              >
              </dx:ASPxImage>

              <dx:ASPxLabel
                ID="ASPxFormLayout1_E10"
                runat="server"
                Text="Create an Account"
                CssClass="heading-register-text"
              >
              </dx:ASPxLabel>

              <dx:ASPxFormLayout
                ID="ASPxFormLayout1"
                runat="server"
                Width="100%"
                ShowItemCaptionColon="False"
                CssClass="Form-container-register-input"
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
                        Caption="First Name"
                        ColSpan="1"
                        Name="first_name"
                      >
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox
                              ID="TB_first_name_register"
                              runat="server"
                              Placeholder="First Name"
                              CssClass="input-register firt-name-text-input-register"
                              NullText="first name"
                              Width="100%"
                            >
                              <ValidationSettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                              >
                                <RequiredField
                                  IsRequired="True"
                                  ErrorText="First Name is required"
                                />
                              </ValidationSettings>
                            </dx:ASPxTextBox>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <CaptionSettings VerticalAlign="Middle" />
                      </dx:LayoutItem>

                      <dx:LayoutItem
                        Caption="Last Name"
                        ColSpan="1"
                        Name="last_name"
                      >
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox
                              ID="TB_last_name_register"
                              runat="server"
                              Placeholder="Last Name"
                              CssClass="input-register last-name-text-input-register"
                              NullText="last name"
                              Width="100%"
                            >
                              <ValidationSettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                              >
                                <RequiredField
                                  IsRequired="True"
                                  ErrorText="Last Name is required"
                                />
                              </ValidationSettings>
                            </dx:ASPxTextBox>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <CaptionSettings VerticalAlign="Middle" />
                      </dx:LayoutItem>

                      <dx:LayoutItem Caption="Email" ColSpan="1" Name="email">
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox
                              ID="TB_email_register"
                              runat="server"
                              Placeholder="user@mail.com"
                              CssClass="input-register email-text-input-register"
                              NullText="ex@mail.com"
                              Width="100%"
                            >
                              <ValidationSettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                                EnableCustomValidation="True"
                              >
                                <RegularExpression
                                  ErrorText="Wrong Email Format"
                                  ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,}$"
                                />
                                <RequiredField
                                  IsRequired="True"
                                  ErrorText="Email is required"
                                />
                              </ValidationSettings>
                            </dx:ASPxTextBox>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                        <CaptionSettings VerticalAlign="Middle" />
                      </dx:LayoutItem>
                      <dx:LayoutItem
                        Caption="Password"
                        ColSpan="1"
                        Name="password"
                      >
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxTextBox
                              ID="TB_pass_register"
                              runat="server"
                              Password="True"
                              CssClass="input-register password-text-input-register"
                              TextMode="Password"
                              Placeholder="Enter your password"
                              Width="100%"
                              NullText="Enter A Password"
                            >
                              <ValidationSettings
                                ErrorTextPosition="Right"
                                Display="Dynamic"
                                ErrorText="*"
                              >
                                <ErrorFrameStyle Wrap="True"> </ErrorFrameStyle>
                                <RegularExpression
                                  ErrorText="Password must be at least 8 characters, contain at least one one lower case letter, one upper case letter,  one digit and one special character"
                                  ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$"
                                />
                                <RequiredField
                                  IsRequired="True"
                                  ErrorText="Password is required"
                                />
                              </ValidationSettings>
                            </dx:ASPxTextBox>
                          </dx:LayoutItemNestedControlContainer>
                        </LayoutItemNestedControlCollection>
                      </dx:LayoutItem>
                      <dx:LayoutItem Caption="" ColSpan="1" ShowCaption="False">
                        <LayoutItemNestedControlCollection>
                          <dx:LayoutItemNestedControlContainer runat="server">
                            <dx:ASPxButton
                              ID="FL_B_Reg"
                              runat="server"
                              CssClass="btn-register"
                              Text="Register"
                              Height="40px"
                              HorizontalAlign="Center"
                              VerticalAlign="Middle"
                              Width="150px"
                              OnClick="FL_B_Reg_Click"
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
                    </Items>
                  </dx:LayoutGroup>
                </Items>
              </dx:ASPxFormLayout>
              <div class="register-container">
                <dx:ASPxLabel
                  ID="ASPxLabel1"
                  runat="server"
                  Text="Have an acount"
                  Font-Size="20px"
                >
                </dx:ASPxLabel>

                <dx:ASPxHyperLink
                  ID="ASPxHyperLink1"
                  CssClass="hyp-register"
                  runat="server"
                  Text="Login"
                  NavigateUrl="~/Login.aspx"
                >
                </dx:ASPxHyperLink>
              </div>
            </dx:PanelContent>
          </PanelCollection>
        </dx:ASPxPanel>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>
</asp:Content>
