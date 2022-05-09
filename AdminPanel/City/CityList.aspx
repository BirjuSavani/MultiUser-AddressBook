<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <h2>City List</h2>
            </div>
            <div class="col-md-6" style="text-align: right">
                <br />
                <asp:HyperLink runat="server" ID="HyperLink8" Text="CityAdd" class="btn btn-outline-warning button1" NavigateUrl="~/AdminPanel/City/Add" Style="color: black"></asp:HyperLink>
 
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12" style="color: red">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 text-center">
                <asp:GridView runat="server" ID="gvCity" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvCity_RowCommand">
                    <Columns>
                        <%--<asp:BoundField DataField="CityID" HeaderText="ID" />--%>
                        <asp:BoundField DataField="CityName" HeaderText="City Name" />
                        <asp:BoundField DataField="STDCode" HeaderText="STD Code" />
                        <asp:BoundField DataField="PinCode" HeaderText="Pin Code" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <%--<asp:BoundField DataField="CountryName" HeaderText="Country" />--%>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ??? ');" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"~/AdminPanel/City/Edit/" + CommonDropDownFillMethods.Base64encode(Eval("CityID").ToString().Trim()) %>' CssClass="btn btn-dark btn-sm"></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        
    </div>
</asp:Content>

