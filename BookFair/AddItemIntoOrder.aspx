<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" ViewStateMode="Enabled"
CodeBehind="AddItemIntoOrder.aspx.cs" Inherits="BookFair.AddItemIntoOrder"
Async="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .element-panel-container {
      margin: auto;
      width: fit-content;
      display: grid;
      padding: 20px;
      max-width: 100%;

      grid-template-columns: repeat(2, 1fr);
      gap: 50px 200px;
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

    .panel-footer-pager-container {
      width: 300px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin: auto;
      /*gap:50px;*/
      margin-top: 20px;
      justify-content: space-evenly;
    }

    .container-btn-pager {
      display: flex;
      flex-direction: row;
      align-items: center;
      justify-content: center;
    }

    .pager-btn {
      background-color: transparent;
      border: none;
      width: 30px;
    }

    .options-container {
      width: 100%;
      padding: 20px;
      display: flex;
      flex-direction: row;
      gap: 50px;
      align-items: center;
      justify-content: center;
    }

    .options-input {
      width: 400px;
      border-radius: 15px;
      height: 35px;
    }

    .options-btn {
      width: fit-content !important;
      padding: 5px 15px 5px 15px;
      border-radius: 15px;
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
      Image-Url="~/utlis/Images/iconBack.svg"
      Image-Width="50px"
    >
      <Image Width="50px" Url="~/utlis/Images/iconBack.svg"></Image>
    </dx:ASPxButton>
    <dx:aspxlabel
      ID="labelPageRedirect"
      CssClass="label-page-redirect"
      Text="Go Back To Order Page"
      runat="server"
    ></dx:aspxlabel>
  </div>

  <dx:aspxpanel
    ID="panelSearchItemsContainer"
    CssClass="options-container search-container"
    runat="server"
    Width="100%"
  >
    <panelcollection>
      <dx:panelcontent>
        <dx:aspxtextbox
          ID="SearchTextInput"
          CssClass="options-input search-input"
          runat="server"
        />
        <dx:aspxbutton
          ID="BtnSearch"
          runat="server"
          Text="Search"
          AutoPostBack="false"
          OnClick="btnSearch_Click"
          CssClass="options-btn btn-search"
        >
        </dx:aspxbutton>
      </dx:panelcontent>
    </panelcollection>
  </dx:aspxpanel>

  <dx:ASPxPanel runat="server" ID="ElementPagerContainer" Width="100%">
    <PanelCollection>
      <dx:PanelContent>
        <dx:aspxpanel
          ID="ElementPanelContainer"
          CssClass="element-panel-container"
          runat="server"
          ViewStateMode="Enabled"
        >
          <panelcollection>
            <dx:panelcontent> </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>

        <dx:aspxpanel
          ID="FooterPagerContainer"
          CssClass="panel-footer-pager-container"
          runat="server"
        >
          <panelcollection>
            <dx:panelcontent>
              <dx:aspxlabel ID="labelPageFooter" runat="server"></dx:aspxlabel>
              <div class="container-btn-pager">
                <dx:aspxbutton
                  ID="btnPagerPrev"
                  CssClass="pager-btn"
                  runat="server"
                  Image-Url="~/utlis/Images/iconPrev.svg"
                  Image-Width="30px"
                  OnClick="btnPagerPrev_Click"
                  AutoPostBack="False"
                >
                  <image Width="30px" Url="~/utlis/Images/iconPrev.svg"></image>
                </dx:aspxbutton>
                <dx:aspxlabel
                  ID="labelPagerNumber"
                  runat="server"
                ></dx:aspxlabel>

                <dx:aspxbutton
                  ID="btnPagerNext"
                  AutoPostBack="false"
                  CssClass="pager-btn"
                  runat="server"
                  Image-Url="~/utlis/Images/iconNext.svg"
                  Image-Width="30px"
                  OnClick="btnPagerNext_Click"
                >
                  <image Width="30px" Url="~/utlis/Images/iconNext.svg"></image>
                </dx:aspxbutton>
              </div>
            </dx:panelcontent>
          </panelcollection>
        </dx:aspxpanel>
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
