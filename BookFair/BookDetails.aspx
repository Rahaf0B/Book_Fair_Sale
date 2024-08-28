<%@ Page Title="" Language="C#" MasterPageFile="~/Root.master"
AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs"
Inherits="BookFair.BookDetails" Async="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="server">
  <style>
    .parent-content-container,
    .sub-info-container,
    .sub-buttons-container,
    .edit-quantity-container,
    .label-value-info {
      display: flex;

      flex-direction: row;
    }
    .parent-content-container {
      align-items: center;
      justify-content: space-evenly;
      box-shadow: 1px 1px 15px 2px rgba(230, 189, 150, 0.6);

      border-radius: 15px;
    }

    .img-container {
      width: 30%;
    }
    .info-container {
      display: flex;
      flex-direction: column;
      align-items: center;
      gap: 25px;
      width: 100%;
      padding-left: 10px;
      padding-right: 10px;
    }
    .sub-info-container {
      width: 100%;
      justify-content: space-around;
      align-items: center;
    }

    .sub-buttons-container {
      align-items: center;
      gap: 25px;
    }

    .label-value-info {
      align-items: center;
      gap: 15px;
      justify-content: center;
      width: 100%;
    }
    .quantity-container-info {
      display: flex;
      flex-direction: column;
      align-items: center;
      gap: 20px;
    }
    .page-redirect-container {
      width: 260px;
      display: flex;
      flex-direction: row;
      align-items: center;
      margin-bottom: 30px;
      padding: 20px;
    }
    .item-img {
      border-radius: 15px;
    }
    .btn-option-page-redirect {
      background-color: transparent;
    }

    .label-page-redirect {
      font-size: 15px;
    }
    .label-text {
      font-size: 20px;
    }
    .btn-option {
      border-radius: 15px;
      font-size: 20px;
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
      Text="Go Back To Home Page"
      runat="server"
    ></dx:aspxlabel>
  </div>
  <dx:ASPxPanel
    ID="ASPxPanelContentContainer"
    CssClass="parent-content-container"
    runat="server"
    Width="100%"
  >
    <PanelCollection>
      <dx:PanelContent>
        <dx:ASPxHiddenField
          ID="ASPxHiddenFieldID"
          runat="server"
        ></dx:ASPxHiddenField>

        <div class="img-container">
          <dx:ASPxImage
            CssClass="item-img"
            ID="ASPxImageItem"
            runat="server"
            ShowLoadingImage="true"
            Width="100%"
          ></dx:ASPxImage>
        </div>

        <div class="info-container">
          <div class="sub-info-container sub-one">
            <div class="label-value-info">
              <dx:ASPxLabel
                ID="ASPxLabelT"
                CssClass="label-text"
                runat="server"
                Text="Title"
              ></dx:ASPxLabel>
              <dx:ASPxLabel
                ID="ASPxInfoTitle"
                runat="server"
                ForeColor="GrayText"
                Font-Size="20px"
              >
              </dx:ASPxLabel>
            </div>
            <div class="label-value-info">
              <dx:ASPxLabel
                ID="ASPxLabelS"
                runat="server"
                CssClass="label-text"
                Text="Subject"
              ></dx:ASPxLabel>
              <dx:ASPxLabel
                ID="ASPxInfoSubject"
                runat="server"
                ForeColor="GrayText"
                Font-Size="20px"
              >
              </dx:ASPxLabel>
            </div>
          </div>
          <div class="label-value-info">
            <dx:ASPxLabel
              ID="ASPxLabelD"
              CssClass="label-text"
              runat="server"
              Text="Description"
            ></dx:ASPxLabel>

            <dx:ASPxLabel
              ID="ASPxInfoDescription"
              runat="server"
              ForeColor="GrayText"
              Font-Size="20px"
            >
            </dx:ASPxLabel>
          </div>
          <div class="sub-info-container sub-two">
            <div class="label-value-info">
              <dx:ASPxLabel
                ID="ASPxLabelA"
                runat="server"
                CssClass="label-text"
                Text="Author"
              ></dx:ASPxLabel>
              <dx:ASPxLabel
                ID="ASPxInfoAuthor"
                runat="server"
                ForeColor="GrayText"
                Font-Size="20px"
              >
              </dx:ASPxLabel>
            </div>
            <div class="label-value-info">
              <dx:ASPxLabel
                ID="ASPxLabelP"
                runat="server"
                CssClass="label-text"
                Text="Price"
              ></dx:ASPxLabel>
              <dx:ASPxLabel
                ID="ASPxInfPrice"
                runat="server"
                ForeColor="GrayText"
                Font-Size="20px"
              >
              </dx:ASPxLabel>
            </div>
          </div>

          <div class="label-value-info">
            <dx:ASPxLabel
              ID="ASPxLabelinfoQ"
              CssClass="label-text"
              runat="server"
              Text="Quantity"
            ></dx:ASPxLabel>

            <dx:ASPxLabel
              ID="ASPxInfQuantity"
              runat="server"
              ForeColor="GrayText"
              Font-Size="20px"
            >
            </dx:ASPxLabel>
          </div>

          <div class="sub-buttons-container">
            <dx:ASPxButton
              ID="ASPxButtonAddToCart"
              CssClass="btn-option"
              runat="server"
              Text="Add To Cart"
              OnClick="ASPxButtonAddToCart_Click"
            ></dx:ASPxButton>
            <dx:ASPxButton
              ID="ASPxButtonEdit"
              runat="server"
              CssClass="btn-option"
              Text="Edit"
              OnClick="ASPxButtonEdit_Click"
            ></dx:ASPxButton>
            <dx:ASPxButton
              ID="ASPxButtonDelete"
              runat="server"
              CssClass="btn-option"
              Text="Delete"
              OnClick="ASPxButtonDelete_Click"
            ></dx:ASPxButton>
          </div>
        </div>
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
