<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <h2>Country List</h2>
            </div>
            <div class="col-md-6" style="text-align: right">
                <br />
                <asp:HyperLink runat="server" ID="HyperLink6" Text="CountryAdd" class="btn btn-outline-warning button1" NavigateUrl="/AdminPanel/Country/Add" Style="color: black" ToolTip="You can add Country"></asp:HyperLink>

            </div>
        </div>
        <br />
        <div class="row text-center">
            <div class="col-md-12">
                <table class="table-hover">
                    <asp:GridView ID="gvCountry" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false" OnRowCommand="gvCountry_RowCommand">
                        <Columns>
                            <%-- <asp:BoundField DataField="CountryID" HeaderText="ID" />--%>
                            <asp:BoundField DataField="CountryName" HeaderText="Country Name" />
                            <asp:BoundField DataField="CountryCode" HeaderText="Country Code" />
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button runat="server" ID="btnDelete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete ??? ');" CssClass="btn btn-danger btn-sm" CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" ID="hlEdit" Text="Edit" NavigateUrl='<%#"/AdminPanel/Country/Edit/" + CommonDropDownFillMethods.Base64encode( Eval("CountryID").ToString() )%>' CssClass="btn btn-dark btn-sm"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </table>
            </div>
        </div>
        <br />

        <div class="row">
            <div class="col-md-12" style="color: red">
                <asp:Label runat="server" ID="lblMessage" EnableViewState="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>

