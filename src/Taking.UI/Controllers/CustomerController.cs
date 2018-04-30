using Microsoft.Ajax.Utilities;
using System;
using System.Net;
using System.Web.Mvc;
using Taking.Application.Interfaces;
using Taking.Application.ViewModels;

namespace Taking.UI.Controllers
{
    //[RoutePrefix("Adm/Gestao/Customer")]
    //[Route("{action=listar-clientes}")]
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // GET: Customer
        //[Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_customerAppService.ObterTodos());
        }

        // GET: Customer/Details/5
        //[Route("detalhes/{id:guid}")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = _customerAppService.ObterPorId(id.Value);
            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

        // GET: Customer/Create
        //[Route("incluir-novo")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("incluir-novo")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                customerViewModel = _customerAppService.Adicionar(customerViewModel);

                if (!customerViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in customerViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }
                    return View(customerViewModel);
                }

                if (!customerViewModel.ValidationResult.Message.IsNullOrWhiteSpace())
                {
                    ViewBag.Sucesso = customerViewModel.ValidationResult.Message;
                    return View(customerViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(customerViewModel);
        }

        // GET: Customer/Edit/5
        //[Route("editar/{id:guid}")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = _customerAppService.ObterPorId(id.Value);
            if (customerViewModel == null)
            {
                return HttpNotFound();
            }

            ViewBag.CustomerId = id;
            return View(customerViewModel);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[Route("editar/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                _customerAppService.Atualizar(customerViewModel);
                return RedirectToAction("Index");
            }
            return View(customerViewModel);
        }

        // GET: Customer/Delete/5
        //[Route("excluir/{id:guid}")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerViewModel customerViewModel = _customerAppService.ObterPorId(id.Value);
            if (customerViewModel == null)
            {
                return HttpNotFound();
            }
            return View(customerViewModel);
        }

        // POST: Customer/Delete/5
        //[Route("excluir/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _customerAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _customerAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
