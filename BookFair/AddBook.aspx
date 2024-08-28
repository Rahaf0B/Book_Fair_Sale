<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="BookFair.AddBook"
Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .input-container,
    .multi-input-container {
      display: flex;
      flex-direction: row;
      align-items: center;
    }
    .input-container {
      gap: 15px;
    }
    .multi-input-container {
      justify-content: space-evenly;
      width: 100%;
    }

    .btn-add {
      float: right;
      width: 150px !important;
      height: 40px;
      border-radius: 15px;
      font-size: 15px;
      color: white;
    }
    .input-elements-container {
      padding: 40px 40px 40px 40px;
      box-shadow: 1px 1px 15px 2px rgba(230, 189, 150, 0.6);
      height: fit-content;
      margin: auto;
      border-radius: 20px;
      width: fit-content;
    }
    .page-label {
      font-size: 40px;
      color: #fa7f06;
      margin: auto;
    }

    .drop-down-select {
      border: #bca8e054 solid;
      color: black;
      background-color: white;
      border-radius: 15px;
      align-items: center;
      text-align: center;
      height: 35px;
      width: 100%;
      font-family: "Concert One", "ConcertOne", sans-serif;
    }
    .input-value {
      width: 100% !important;
      height: 35px;
      padding: 0 20px;
    }

    .input-value,
    .dxeMemoEditAreaSys {
      border-radius: 15px;
      border: #bca8e054 solid;
    }
    .btn-browse {
      border: none;
      background-color: #fa7f06;
      color: white;
      border-radius: 0 15px 15px 0;
      font-size: 15px;
    }
    .dx-al {
      border-radius: 15px 0 0 15px;
    }

    .label-input {
      font-size: 20px;
    }

    .btn-selsct-drop-down {
      border-radius: 0 15px 15px 0;
    }

    .label-page-container {
      width: fit-content;
    }

    #ASPxPopupControl1_PW0,
    .pop-up-window,
    .pop-up-window-container {
      left: 50% !important;
      top: 50% !important;
      transform: translateX(-50%);
      width: 400px;
      height: 100px;
    }

    .pop-up-window .dxpc-window {
      position: fixed;
      top: 50%;
      left: 50%;
      transform: translate(-50%, -50%);
    }

    .pop-up-window-container {
      position: absolute;
    }

    #ContentPopUpWindow {
      left: 50% !important;
      top: 50% !important;
      transform: translateX(-50%);
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
  <dx:ASPxPanel
    ID="ASPxPanel1"
    CssClass="page-container"
    runat="server"
    Width="100%"
  >
    <PanelCollection>
      <dx:PanelContent>
        <div class="page-redirect-container">
          <dx:ASPxButton
            ID="ASPxButtonBack"
            CausesValidation="false"
            UseSubmitBehavior="false"
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
            Text="Go Back To Home Page"
            runat="server"
          ></dx:aspxlabel>
        </div>

        <dx:ASPxFormLayout
          ID="ASPxFormLayout1"
          runat="server"
          CssClass="input-elements-container"
        >
          <Items>
            <dx:LayoutItem
              Caption=""
              ColSpan="1"
              CssClass="label-page-container"
              ShowCaption="False"
            >
              <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                  <dx:ASPxLabel
                    ID="ASPxFormLayout1_E1"
                    runat="server"
                    CssClass="page-label"
                    Text="Add New Book"
                  >
                  </dx:ASPxLabel>
                </dx:LayoutItemNestedControlContainer>
              </LayoutItemNestedControlCollection>
            </dx:LayoutItem>
            <dx:LayoutGroup
              Caption=""
              ColCount="2"
              ColSpan="1"
              ColumnCount="2"
              ShowCaption="False"
              Paddings-PaddingTop="30px"
            >
              <Border BorderStyle="None" />

              <Paddings PaddingTop="30px"></Paddings>

              <GroupBoxStyle>
                <Border BorderStyle="None" />
              </GroupBoxStyle>
              <CellStyle>
                <Border BorderStyle="None" />
              </CellStyle>
              <Items>
                <dx:LayoutItem
                  Caption="Title"
                  ColSpan="1"
                  CssClass="label-input"
                >
                  <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                      <dx:ASPxTextBox
                        ID="ASPxFormLayoutTitle"
                        runat="server"
                        CssClass="input-value"
                      >
                        <ValidationSettings Display="Dynamic">
                          <RequiredField
                            ErrorText="The Title Is Required"
                            IsRequired="True"
                          />
                        </ValidationSettings>
                      </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                  </LayoutItemNestedControlCollection>
                  <Paddings PaddingBottom="30px" PaddingTop="30px" />
                </dx:LayoutItem>
                <dx:LayoutItem Caption="Publisher" ColSpan="1">
                  <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                      <dx:ASPxTextBox
                        ID="ASPxFormLayoutPublisher"
                        runat="server"
                        CssClass="input-value"
                      >
                      </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                  </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
              </Items>
            </dx:LayoutGroup>
            <dx:LayoutItem
              Caption="Description"
              ColSpan="1"
              CssClass="label-input"
              Paddings-PaddingTop="30px"
            >
              <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                  <dx:ASPxMemo
                    ID="ASPxFormLayoutDescription"
                    runat="server"
                    Height="70px"
                    Width="300px"
                    MaxLength="200"
                  >
                    <Border BorderStyle="None"></Border>
                  </dx:ASPxMemo>
                </dx:LayoutItemNestedControlContainer>
              </LayoutItemNestedControlCollection>

              <Paddings PaddingTop="30px" PaddingBottom="30px"></Paddings>
            </dx:LayoutItem>
            <dx:LayoutGroup
              ColCount="2"
              ColSpan="1"
              ColumnCount="2"
              HorizontalAlign="Center"
              VerticalAlign="Middle"
              ShowCaption="False"
              Paddings-PaddingTop="30px"
            >
              <Border BorderStyle="None" />

              <Paddings PaddingTop="30px"></Paddings>

              <GroupBoxStyle>
                <Border BorderStyle="None" />
              </GroupBoxStyle>
              <CellStyle>
                <Border BorderStyle="None" />
              </CellStyle>
              <Items>
                <dx:LayoutItem
                  Caption="Quantity"
                  ColSpan="1"
                  CssClass="label-input"
                >
                  <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                      <dx:ASPxTextBox
                        ID="ASPxFormLayoutQuantity"
                        runat="server"
                        CssClass="input-value"
                      >
                        <ValidationSettings Display="Dynamic">
                          <RegularExpression
                            ErrorText="The Quntity should be number"
                            ValidationExpression="^-?\d+$"
                          />
                          <RequiredField
                            ErrorText="The Quantiti Is Required"
                            IsRequired="True"
                          />
                        </ValidationSettings>
                      </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                  </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem
                  Caption="Price"
                  ColSpan="1"
                  CssClass="label-input"
                >
                  <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                      <dx:ASPxTextBox
                        ID="ASPxFormLayoutPrice"
                        runat="server"
                        CssClass="input-value"
                      >
                        <ValidationSettings Display="Dynamic">
                          <RegularExpression
                            ErrorText="The Price should be number"
                            ValidationExpression="^-?\d+(\.\d+)?$"
                          />
                          <RequiredField
                            ErrorText="The Price Is Required"
                            IsRequired="True"
                          />
                        </ValidationSettings>
                      </dx:ASPxTextBox>
                    </dx:LayoutItemNestedControlContainer>
                  </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
              </Items>
            </dx:LayoutGroup>
            <dx:LayoutGroup
              ColCount="2"
              ColSpan="1"
              ColumnCount="2"
              HorizontalAlign="Center"
              VerticalAlign="Middle"
              ShowCaption="False"
              Paddings-PaddingTop="30px"
            >
              <Border BorderStyle="None" />

              <Paddings PaddingTop="30px"></Paddings>

              <GroupBoxStyle>
                <Border BorderStyle="None" />
              </GroupBoxStyle>
              <CellStyle>
                <Border BorderStyle="None" />
              </CellStyle>
              <Items>
                <dx:LayoutItem
                  Caption="Subject"
                  ColSpan="1"
                  CssClass="label-input"
                >
                  <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                      <dx:ASPxComboBox
                        ID="ASPxFormLayoutSubject"
                        runat="server"
                        CssClass="drop-down-select"
                      >
                        <ButtonStyle CssClass="btn-selsct-drop-down">
                        </ButtonStyle>
                        <ValidationSettings
                          EnableCustomValidation="True"
                          Display="Dynamic"
                        >
                          <RequiredField
                            ErrorText="The Subject Is Required"
                            IsRequired="True"
                          />
                        </ValidationSettings>
                      </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                  </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
                <dx:LayoutItem
                  Caption="Author"
                  ColSpan="1"
                  CssClass="label-input"
                >
                  <LayoutItemNestedControlCollection>
                    <dx:LayoutItemNestedControlContainer runat="server">
                      <dx:ASPxComboBox
                        ID="ASPxFormLayoutAuthor"
                        runat="server"
                        CssClass="drop-down-select"
                      >
                        <ButtonStyle CssClass="btn-selsct-drop-down">
                        </ButtonStyle>
                        <ValidationSettings
                          EnableCustomValidation="True"
                          Display="Dynamic"
                        >
                          <RequiredField
                            ErrorText="The Author Is Required"
                            IsRequired="True"
                          />
                        </ValidationSettings>
                      </dx:ASPxComboBox>
                    </dx:LayoutItemNestedControlContainer>
                  </LayoutItemNestedControlCollection>
                </dx:LayoutItem>
              </Items>
            </dx:LayoutGroup>
            <dx:LayoutItem
              Caption="Image"
              ColSpan="1"
              CssClass="label-input"
              Paddings-PaddingTop="30px"
            >
              <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                  <dx:ASPxUploadControl
                    ID="ASPxFormLayoutUploadImage"
                    runat="server"
                  >
                    <ValidationSettings AllowedFileExtensions=".png, .jpg">
                    </ValidationSettings>
                    <ClearFileSelectionImage
                      Url="~/utlis/Images/iconClear.svg"
                      Width="15px"
                      SpriteProperties-DisabledCssClass="image-btn-file-upload"
                      UrlDisabled="utlis/Images/iconClear.svg"
                    >
                      <SpriteProperties
                        DisabledCssClass="image-btn-file-upload"
                      ></SpriteProperties>
                    </ClearFileSelectionImage>

                    <BrowseButtonStyle
                      CssClass="btn-browse"
                      ForeColor="White"
                      Font-Size="15px"
                    >
                    </BrowseButtonStyle>
                    <TextBoxStyle
                      Border-BorderColor="#fa7f06"
                      Border-BorderWidth="3px"
                    >
                      <Border BorderColor="#fa7f06" BorderWidth="3px"></Border>
                    </TextBoxStyle>
                  </dx:ASPxUploadControl>
                </dx:LayoutItemNestedControlContainer>
              </LayoutItemNestedControlCollection>

              <Paddings PaddingTop="30px" PaddingBottom="30px"></Paddings>
            </dx:LayoutItem>
            <dx:LayoutItem
              Caption=""
              ColSpan="1"
              Paddings-PaddingTop="30px"
              ShowCaption="False"
            >
              <LayoutItemNestedControlCollection>
                <dx:LayoutItemNestedControlContainer runat="server">
                  <dx:ASPxButton
                    ID="ASPxFormLayout1_E16"
                    runat="server"
                    CssClass="btn-add"
                    ForeColor="White"
                    Text="Add Book"
                    OnClick="ASPxFormLayout1_E16_Click"
                  >
                  </dx:ASPxButton>
                </dx:LayoutItemNestedControlContainer>
              </LayoutItemNestedControlCollection>

              <Paddings PaddingTop="10px" PaddingBottom="10px"></Paddings>
            </dx:LayoutItem>
            <dx:layoutitem Caption ColSpan="1" ShowCaption="False">
              <layoutitemnestedcontrolcollection>
                <dx:layoutitemnestedcontrolcontainer runat="server">
                  <dx:aspxvalidationsummary
                    ID="ASPxValidationSummary1"
                    runat="server"
                    RenderMode="BulletedList"
                  >
                  </dx:aspxvalidationsummary>
                </dx:layoutitemnestedcontrolcontainer>
              </layoutitemnestedcontrolcollection>
            </dx:layoutitem>
          </Items>
          <SettingsItems HorizontalAlign="Center" VerticalAlign="Middle" />
        </dx:ASPxFormLayout>
      </dx:PanelContent>
    </PanelCollection>
  </dx:ASPxPanel>

  <dx:aspxpopupcontrol
    ID="ASPxPopupControl1"
    CssClass="pop-up-window"
    runat="server"
    CloseAction="CloseButton"
    Left="50"
    Top="50"
    Width="400px"
    Height="100px"
    ContentStyle-HorizontalAlign="Center"
    ContentStyle-VerticalAlign="Middle"
    ContentStyle-Wrap="True"
    ClientIDMode="Static"
    PopupElementID="PopUpWindowElement"
    ShowOnPageLoad="True"
  >
    <windows>
      <dx:popupwindow
        CloseAction="CloseButton"
        ScrollBars="None"
        ShowCloseButton="True"
        ShowFooter="False"
        ShowHeader="True"
        ShowMaximizeButton="False"
        ShowOnPageLoad="True"
        ShowPinButton="False"
        ShowRefreshButton="False"
        Width="100%"
        Height="100%"
        HeaderText="*"
      >
        <contentstyle HorizontalAlign="Center" VerticalAlign="Middle">
          <paddings Padding="20px" />
        </contentstyle>
        <contentcollection>
          <dx:popupcontrolcontentcontrol runat="server">
          </dx:popupcontrolcontentcontrol>
        </contentcollection>
      </dx:popupwindow>
    </windows>

    <contentstyle
      HorizontalAlign="Center"
      VerticalAlign="Middle"
      Wrap="True"
    ></contentstyle>
    <contentcollection>
      <dx:popupcontrolcontentcontrol runat="server">
      </dx:popupcontrolcontentcontrol>
    </contentcollection>
  </dx:aspxpopupcontrol>
</asp:Content>
